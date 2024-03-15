using System.Security.Cryptography;
using System.Text;

namespace Sha.Business.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class WeChatHelper
    {
        /// <summary>
        /// 构建消息
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static string BuildMessage(string uri, string method, string timestamp, string nonce, string body) => $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";
    }
}
