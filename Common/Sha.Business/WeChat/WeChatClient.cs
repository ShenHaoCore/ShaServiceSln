using Microsoft.Extensions.Logging;
using RestSharp;
using Sha.Framework.Common;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Sha.Business.WeChat
{
    /// <summary>
    /// 微信客户端
    /// </summary>
    public class WeChatClient : IWeChatClient
    {
        private readonly ILogger<WeChatClient> logger;
        private readonly WeChatConfig config;
        private readonly RSAHelper rsa;

        /// <summary>
        /// 微信客户端
        /// </summary>
        /// <param name="logger"></param>
        public WeChatClient(ILogger<WeChatClient> logger)
        {
            this.logger = logger;
            var wechatConfig = AppSettings.GetObject<WeChatConfig>(WeChatConfig.KEY);
            if (wechatConfig == null) { throw new ArgumentNullException(nameof(wechatConfig)); }
            this.config = wechatConfig;
            this.rsa = new RSAHelper(HashAlgorithmName.SHA256, Encoding.UTF8, config.PrivateKey, "");
        }

        public readonly string Accept = "application/json";
        public readonly string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

        /// <summary>
        /// 
        /// </summary>
        public string Nonce => Guid.NewGuid().ToString("N");

        /// <summary>
        /// 
        /// </summary>
        public string TimeStamp => DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public string BuildMessage(string uri, string method, string timestamp, string nonce, string body) => $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private string BuildToken(string url, string method, string body)
        {
            string uri = new Uri(url).PathAndQuery;
            string message = BuildMessage(uri, method, TimeStamp, Nonce, body);
            string sign = rsa.Sign(message);
            return $"mchid=\"{config.MchId}\",nonce_str=\"{Nonce}\",timestamp=\"{TimeStamp}\",serial_no=\"{config.MchSerialNo}\",signature=\"{sign}\"";
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetCertificates()
        {
            try
            {
                string url = "https://api.mch.weixin.qq.com/v3/certificates";
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest();
                string token = BuildToken(url, "GET", "");
                request.AddHeader("Authorization", $"WECHATPAY2-SHA256-RSA2048 {token}");
                request.AddHeader("Accept", Accept); // 如果缺少这句代码就会导致下单接口请求失败，报400错误（Bad Request）
                request.AddHeader("User-Agent", UserAgent); // 如果缺少这句代码就会导致下单接口请求失败，报400错误（Bad Request）
                RestResponse response = client.Get(request);
                logger.LogDebug($"微信V3获取证书：{response}");
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    string content = response.Content ?? "";
                }
            }
            catch
            {

            }
        }
    }
}
