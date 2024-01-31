using Sha.Common.Extension;
using System.Security.Cryptography;
using System.Text;

namespace Sha.Common.Helper
{
    /// <summary>
    /// RSA 帮助类
    /// </summary>
    public class RsaHelper
    {
        /// <summary>
        /// 初始化一个<see cref="RsaHelper"/>类的新实例
        /// </summary>
        public RsaHelper()
        {
            RSA rsa = RSA.Create();
            PublicKey = rsa.ToXmlString2(false);
            PrivateKey = rsa.ToXmlString2(true);
        }

        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; }

        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; }

        #region 实例方法
        /// <summary>
        /// 加密字节数组
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] source) => Encrypt(source, PublicKey);

        /// <summary>
        /// 使用指定公钥加密字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static string Encrypt(string source, string publicKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            bytes = Encrypt(bytes, publicKey);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 解密字节数组
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] source) => Decrypt(source, PrivateKey);

        /// <summary>
        /// 使用指定私钥解密字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string Decrypt(string source, string privateKey)
        {
            byte[] bytes = Convert.FromBase64String(source);
            bytes = Decrypt(bytes, privateKey);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// 对明文进行签名，返回明文签名的字节数组
        /// </summary>
        /// <param name="source">要签名的明文字节数组</param>
        /// <returns>明文签名的字节数组</returns>
        public byte[] SignData(byte[] source) => SignData(source, PrivateKey);

        /// <summary>
        /// 使用指定私钥签名字符串
        /// </summary>
        /// <param name="source">要签名的字符串</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public static string SignData(string source, string privateKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            byte[] signBytes = SignData(bytes, privateKey);
            return Convert.ToBase64String(signBytes);
        }

        /// <summary>
        /// 验证解密得到的明文是否符合签名
        /// </summary>
        /// <param name="source">解密的明文字节数组</param>
        /// <param name="signData">明文签名字节数组</param>
        /// <returns>验证是否通过</returns>
        public bool VerifyData(byte[] source, byte[] signData) => VerifyData(source, signData, PublicKey);

        /// <summary>
        /// 使用指定公钥验证解密得到的明文是否符合签名
        /// </summary>
        /// <param name="source">解密得到的明文</param>
        /// <param name="signData">明文签名的BASE64字符串</param>
        /// <param name="publicKey">公钥</param>
        /// <returns>验证是否通过</returns>
        public static bool VerifyData(string source, string signData, string publicKey)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            byte[] signBytes = Convert.FromBase64String(signData);
            return VerifyData(sourceBytes, signBytes, publicKey);
        }
        #endregion

        /// <summary>
        /// 使用指定公钥加密字节数组
        /// </summary>
        /// <param name="data"></param>
        /// <param name="publicKey">公钥</param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] data, string publicKey)
        {
            RSA rsa = RSA.Create();
            rsa.FromXmlString2(publicKey);
            return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
        }

        /// <summary>
        /// 使用私钥解密字节数组
        /// </summary>
        /// <param name="data">要解密的密文字节数组</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] data, string privateKey)
        {
            RSA rsa = RSA.Create();
            rsa.FromXmlString2(privateKey);
            return rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
        }

        /// <summary>
        /// 使用指定私钥对明文进行签名，返回明文签名的字节数组
        /// </summary>
        /// <param name="source">要签名的明文字节数组</param>
        /// <param name="privateKey">私钥</param>
        /// <returns>明文签名的字节数组</returns>
        public static byte[] SignData(byte[] source, string privateKey)
        {
            RSA rsa = RSA.Create();
            rsa.FromXmlString2(privateKey);
            return rsa.SignData(source, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
        }

        /// <summary>
        /// 使用指定公钥验证解密得到的明文是否符合签名
        /// </summary>
        /// <param name="source">解密的明文字节数组</param>
        /// <param name="signData">明文签名字节数组</param>
        /// <param name="publicKey">公钥</param>
        /// <returns>验证是否通过</returns>
        public static bool VerifyData(byte[] source, byte[] signData, string publicKey)
        {
            RSA rsa = RSA.Create();
            rsa.FromXmlString2(publicKey);
            return rsa.VerifyData(source, signData, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
        }
    }
}
