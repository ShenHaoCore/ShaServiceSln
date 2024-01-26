namespace Sha.Business.Alipay
{
    /// <summary>
    /// 
    /// </summary>
    public class AlipaySetting
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "Alipay";

        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppID { get; set; } = string.Empty;

        /// <summary>
        /// 商家私钥
        /// </summary>
        public string MerchantPrivateKey { get; set; } = string.Empty;

        /// <summary>
        /// 商家公钥
        /// </summary>
        public string MerchantPublicKey { get; set; } = string.Empty;

        /// <summary>
        /// 支付宝公钥
        /// </summary>
        public string AlipayPublicKey { get; set; } = string.Empty;

        /// <summary>
        /// 服务地址
        /// </summary>
        public string ServerUrl { get; set; } = string.Empty;

        /// <summary>
        /// 异步通知地址
        /// </summary>
        public string NotifyUrl { get; set; } = string.Empty;

        /// <summary>
        /// 同步通知地址
        /// </summary>
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
