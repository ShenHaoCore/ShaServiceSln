using System.Security.Cryptography;
using System.Text;

namespace Sha.Framework.Common
{
    /// <summary>
    /// MD5帮助类
    /// </summary>
    public class MD5Helper
    {
        /// <summary>
        /// MD5编码
        /// </summary>
        /// <param name="input">明文</param>
        /// <returns></returns>
        public static string MD5Encoding(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = MD5.HashData(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}
