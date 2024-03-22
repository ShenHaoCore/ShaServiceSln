using Microsoft.Extensions.Logging;
using RestSharp;
using Sha.Common.Extension;
using Sha.Common.Helper;
using Sha.Framework.Common;
using System.Collections.Concurrent;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sha.Business.WeChat
{
    /// <summary>
    /// 微信客户端
    /// </summary>
    public class WeChatMerchant : IWeChatMerchant
    {
        private readonly ILogger<WeChatMerchant> logger;
        private readonly WeChatSetting setting;

        /// <summary>
        /// 微信客户端
        /// </summary>
        /// <param name="logger"></param>
        public WeChatMerchant(ILogger<WeChatMerchant> logger)
        {
            this.logger = logger;
            this.setting = AppSettingHelper.GetObject<WeChatSetting>(WeChatSetting.KEY) ?? throw new ArgumentNullException();
        }

        private const string V3_CERTIFICATE = "https://api.mch.weixin.qq.com/v3/certificates";
        private const string V3_PAY_TRADE_APP = "https://api.mch.weixin.qq.com/v3/pay/transactions/app";
        private const string PAY2_SHA256_RSA2048 = "WECHATPAY2-SHA256-RSA2048";

        private readonly string Accept = "application/json";
        private readonly string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
        private readonly ConcurrentDictionary<string, PlatformCert> certs = new();

        /// <summary>
        /// 获取证书
        /// <para>700BAAFDC1CD14D0381E4237432AADEA7E7DA9A7</para>
        /// </summary>
        /// <param name="serialno">序列号</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public PlatformCert? GetPlatformCert(string serialno)
        {
            PlatformCert? wcCert;
            if (certs.TryGetValue(serialno, out wcCert)) { return wcCert; }                             // 如果证书序列号已缓存，则直接使用缓存的证书
            try
            {
                RestClient client = new RestClient(V3_CERTIFICATE);
                RestRequest request = new RestRequest();
                string token = WeChatHelper.GenerateToken(V3_CERTIFICATE, "GET", "", setting.PrivateKey, setting.MchId, setting.SerialNo);
                logger.LogDebug($"微信V3获取证书 TOKEN：{PAY2_SHA256_RSA2048} {token}");
                request.AddHeader("Authorization", $"{PAY2_SHA256_RSA2048} {token}");
                request.AddHeader("Accept", Accept);                                                    // 如果缺少这句代码就会导致下单接口请求失败，报400错误（Bad Request）
                request.AddHeader("User-Agent", UserAgent);                                             // 如果缺少这句代码就会导致下单接口请求失败，报400错误（Bad Request）
                RestResponse response = client.Get(request);
                logger.LogDebug($"微信V3获取证书：{response}");
                if (response is null || response.StatusCode != HttpStatusCode.OK) { return null; }
                var certResponse = response.Content.ToObject<CertResponse>();
                ArgumentNullException.ThrowIfNull(certResponse);
                foreach (Cert item in certResponse.Certs)
                {
                    if (certs.ContainsKey(item.SerialNo)) { continue; }
                    string plaintext = AesHelper.GcmDecrypt(setting.APIv3Key, item.EncryptCert.AssociatedData, item.EncryptCert.Nonce, item.EncryptCert.Ciphertext);
                    X509KeyStorageFlags flags = X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable;
                    byte[] rawData = Encoding.ASCII.GetBytes(plaintext);
                    PlatformCert cert = new(setting.MchId, item.SerialNo, item.EffectiveTime, item.ExpireTime, new(rawData, string.Empty, flags));
                    certs.TryAdd(item.SerialNo, cert);
                }
                if (certs.TryGetValue(serialno, out wcCert)) { return wcCert; }
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
        public TradeAppPayResponse? TradeAppPay(TradeAppPayModel bizmodel)
        {
            RestClient client = new RestClient(V3_PAY_TRADE_APP);
            RestRequest request = new RestRequest();
            string token = WeChatHelper.GenerateToken(V3_PAY_TRADE_APP, "POST", "", setting.PrivateKey, setting.MchId, setting.SerialNo);
            return null;
        }
    }
}
