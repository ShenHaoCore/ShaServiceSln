using System.Security.Cryptography;
using System.Text;

namespace Sha.Common.Helper
{
    /// <summary>
    /// MD5帮助类
    /// </summary>
    public class MD5Helper
    {
        /// <summary>
        /// MD5编码
        /// </summary>
        /// <param name="text">明文</param>
        /// <returns></returns>
        public static string MD5Encoding(string text)
        {
            var inputBytes = Encoding.UTF8.GetBytes(text);
            var hashBytes = MD5.HashData(inputBytes);
            return Convert.ToHexString(hashBytes);
        }

        /// <summary>
        /// MD5编码
        /// </summary>
        /// <param name="text">明文</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string MD5Encoding(string text, string salt) => MD5Encoding($"{text}{salt}");
    }
}
