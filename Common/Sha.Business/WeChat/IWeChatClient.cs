namespace Sha.Business.WeChat
{
    /// <summary>
    /// 微信客户端
    /// </summary>
    public interface IWeChatClient
    {
        /// <summary>
        /// 获取证书
        /// </summary>
        /// <param name="serialno"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        WeChatCertificate? GetCertificates(string serialno);
    }
}
