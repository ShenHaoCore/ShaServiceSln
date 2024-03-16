using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System.Text;

namespace Sha.Common.Helper
{
    /// <summary>
    /// AES 帮助类
    /// </summary>
    public class AesHelper
    {
        /// <summary>
        /// 报文解密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="associatedData"></param>
        /// <param name="nonce"></param>
        /// <param name="ciphertext">密文</param>
        /// <returns></returns>
        public static string GcmDecrypt(string key, string associatedData, string nonce, string ciphertext)
        {
            GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
            AeadParameters aeadParameters = new AeadParameters(new KeyParameter(Encoding.UTF8.GetBytes(key)), 128, Encoding.UTF8.GetBytes(nonce), Encoding.UTF8.GetBytes(associatedData));
            gcmBlockCipher.Init(false, aeadParameters);
            byte[] data = Convert.FromBase64String(ciphertext);
            byte[] plaintext = new byte[gcmBlockCipher.GetOutputSize(data.Length)];
            int length = gcmBlockCipher.ProcessBytes(data, 0, data.Length, plaintext, 0);
            gcmBlockCipher.DoFinal(plaintext, length);
            return Encoding.UTF8.GetString(plaintext);
        }
    }
}
