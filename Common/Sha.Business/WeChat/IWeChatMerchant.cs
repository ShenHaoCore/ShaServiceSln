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
        /// <param name="serialNo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        WeChatCert? GetCert(string serialNo);
    }
}
