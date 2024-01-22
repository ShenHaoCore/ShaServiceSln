using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using Sha.Framework.Common;
using System.Collections.Concurrent;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
            var wechatConfig = AppSettingHelper.GetObject<WeChatConfig>(WeChatConfig.KEY);
            if (wechatConfig == null) { throw new ArgumentNullException(nameof(wechatConfig)); }
            this.config = wechatConfig;
        }

        private const string WECHAT_V3_URL_CERTIFICATE = "https://api.mch.weixin.qq.com/v3/certificates";
        private const string WECHAT_V3_URL_PAY_TRADE_APP = "https://api.mch.weixin.qq.com/v3/pay/transactions/app";
        private const string WECHATPAY2_RSA_2048_WITH_SHA256 = "WECHATPAY2-SHA256-RSA2048";

        private readonly string Accept = "application/json";
        private readonly string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
        private readonly ConcurrentDictionary<string, WeChatCertificate> certs = new();

        /// <summary>
        /// 获取证书
        /// </summary>
        /// <param name="serialno"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public WeChatCertificate? GetCertificates(string serialno)
        {
            WeChatCertificate? platformCert;
            if (certs.TryGetValue(serialno, out platformCert)) { return platformCert; } // 如果证书序列号已缓存，则直接使用缓存的证书
            try
            {
                RestClient client = new RestClient(WECHAT_V3_URL_CERTIFICATE);
                RestRequest request = new RestRequest();
                string token = BuildToken(WECHAT_V3_URL_CERTIFICATE, "GET", "");
                logger.LogDebug($"微信V3获取证书 TOKEN：{WECHATPAY2_RSA_2048_WITH_SHA256} {token}");
                request.AddHeader("Authorization", $"{WECHATPAY2_RSA_2048_WITH_SHA256} {token}");
                request.AddHeader("Accept", Accept); // 如果缺少这句代码就会导致下单接口请求失败，报400错误（Bad Request）
                request.AddHeader("User-Agent", UserAgent); // 如果缺少这句代码就会导致下单接口请求失败，报400错误（Bad Request）
                RestResponse response = client.Get(request);
                logger.LogDebug($"微信V3获取证书：{response}");
                if (response == null || response.StatusCode != HttpStatusCode.OK) { return null; }
                var certResponse = JsonConvert.DeserializeObject<WeChatCertificatesResponse>(response.Content ?? "");
                if (certResponse == null) { throw new ArgumentNullException(nameof(certResponse)); }
                foreach (var item in certResponse.Certificates)
                {
                    if (certs.ContainsKey(item.SerialNo)) { continue; }
                    string certificate = AesGcmDecrypt(item.EncryptCertificate.AssociatedData, item.EncryptCertificate.Nonce, item.EncryptCertificate.Ciphertext);
                    X509Certificate2 x509 = new X509Certificate2(Encoding.ASCII.GetBytes(certificate), string.Empty, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                    WeChatCertificate cert = new WeChatCertificate(config.MchId, item.SerialNo, item.EffectiveTime, item.ExpireTime, x509);
                    certs.TryAdd(item.SerialNo, cert);
                }
                if (certs.TryGetValue(serialno, out platformCert)) { return platformCert; }
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "微信V3获取证书异常");
                return null;
            }
        }

        /// <summary>
        /// APP支付
        /// </summary>
        /// <param name="bizmodel"></param>
        /// <returns></returns>
        public WeChatTradeAppPayResponse? TradeAppPay(WeChatTradeAppPayModel bizmodel)
        {
            RestClient client = new RestClient(WECHAT_V3_URL_PAY_TRADE_APP);
            RestRequest request = new RestRequest();
            string token = BuildToken(WECHAT_V3_URL_PAY_TRADE_APP, "POST", "");
            return null;
        }

        /// <summary>
        /// 构建消息
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
        /// 构建TOKEN
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private string BuildToken(string url, string method, string body)
        {
            string uri = new Uri(url).PathAndQuery;
            string timeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            string nonce = Guid.NewGuid().ToString("N");
            string message = BuildMessage(uri, method, timeStamp, nonce, body);
            string sign = Sign(message);
            return $"mchid=\"{config.MchId}\",nonce_str=\"{nonce}\",timestamp=\"{timeStamp}\",serial_no=\"{config.SerialNo}\",signature=\"{sign}\"";
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string Sign(string message)
        {
            using (RSA rsa = RSA.Create())
            {
                byte[] keyData = Convert.FromBase64String(config.PrivateKey);
                rsa.ImportPkcs8PrivateKey(keyData, bytesRead: out _);
                var signbytes = rsa.SignData(Encoding.UTF8.GetBytes(message), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                return Convert.ToBase64String(signbytes);
            }
        }

        /// <summary>
        /// 报文解密
        /// </summary>
        /// <param name="associatedData"></param>
        /// <param name="nonce"></param>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public string AesGcmDecrypt(string associatedData, string nonce, string ciphertext)
        {
            using (AesGcm aes = new AesGcm(Encoding.UTF8.GetBytes(config.APIv3Key), 1024))
            {
                byte[]? associatedBytes = associatedData == null ? null : Encoding.UTF8.GetBytes(associatedData);
                var encryptedBytes = Convert.FromBase64String(ciphertext);
                var cipherBytes = encryptedBytes[..^16];
                var tag = encryptedBytes[^16..];
                var decryptedData = new byte[cipherBytes.Length];
                aes.Decrypt(Encoding.UTF8.GetBytes(nonce), cipherBytes, tag, decryptedData, associatedBytes);
                return Encoding.UTF8.GetString(decryptedData);
            }
        }
    }
}
