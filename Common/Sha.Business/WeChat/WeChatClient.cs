using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        }

        private readonly string Accept = "application/json";
        private readonly string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

        /// <summary>
        /// 
        /// </summary>
        private string GetNonce()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 
        /// </summary>
        private string GetTimeStamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private string BuildMessage(string uri, string method, string timestamp, string nonce, string body)
        {
            return $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";
        }

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
            string timeStamp = GetTimeStamp();
            string nonce = GetNonce();
            string message = BuildMessage(uri, method, timeStamp, nonce, body);
            string sign = Sign(message);
            return $"mchid=\"{config.MchId}\",nonce_str=\"{nonce}\",timestamp=\"{timeStamp}\",serial_no=\"{config.MchSerialNo}\",signature=\"{sign}\"";
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string Sign(string message)
        {
            byte[] keyData = Convert.FromBase64String(config.PrivateKey);
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportPkcs8PrivateKey(keyData, bytesRead: out _);
                var signbytes = rsa.SignData(Encoding.UTF8.GetBytes(message), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                return Convert.ToBase64String(signbytes);
            }
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
                logger.LogDebug($"微信V3获取证书 TOKEN：WECHATPAY2-SHA256-RSA2048 {token}");
                request.AddHeader("Authorization", $"WECHATPAY2-SHA256-RSA2048 {token}");
                request.AddHeader("Accept", Accept); // 如果缺少这句代码就会导致下单接口请求失败，报400错误（Bad Request）
                request.AddHeader("User-Agent", UserAgent); // 如果缺少这句代码就会导致下单接口请求失败，报400错误（Bad Request）
                RestResponse response = client.Get(request);
                logger.LogDebug($"微信V3获取证书：{response}");

                if (response == null || response.StatusCode != HttpStatusCode.OK) { return; }
                var certResponse = JsonConvert.DeserializeObject<WeChatCertificatesResponse>(response.Content ?? "");
            }
            catch
            {

            }
        }
    }
}
