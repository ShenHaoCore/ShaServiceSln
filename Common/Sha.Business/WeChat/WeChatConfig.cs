namespace Sha.Business.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class WeChatConfig
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "WeChat";

        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppID { get; set; } = string.Empty;

        /// <summary>
        /// 商户ID
        /// </summary>
        public string MchId { get; set; } = string.Empty;

        /// <summary>
        /// 商户证书序列号
        /// </summary>
        public string MchSerialNo { get; set; } = string.Empty;

        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; } = string.Empty;
    }
}
