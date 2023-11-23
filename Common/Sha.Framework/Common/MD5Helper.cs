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
        /// <param name="text"></param>
        /// <returns></returns>
        public static string MD5Encoding(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(textBytes);
                StringBuilder byteStr = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++) { byteStr.Append(hashBytes[i].ToString("x2")); } // 以十六进制格式格式化
                return byteStr.ToString();
            }
        }
    }
}
