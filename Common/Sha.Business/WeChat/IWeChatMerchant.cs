namespace Sha.Business.WeChat
{
    /// <summary>
    /// 微信客户端
    /// </summary>
    public interface IWeChatMerchant
    {
        /// <summary>
        /// 获取证书
        /// </summary>
        /// <param name="serialno">序列号<para>示例值：700BAAFDC1CD14D0381E4237432AADEA7E7DA9A7</para></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        PlatformCert? GetPlatformCert(string serialno);
    }
}
