using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
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
        public static string CreateMessage(string uri, string method, string timestamp, string nonce, string body) => $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="privateKey">私钥</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static string GenerateSign(string privateKey, string message)
        {
            using RSA rsa = RSA.Create();
            byte[] keyByte = Convert.FromBase64String(privateKey);
            byte[] messageByte = Encoding.UTF8.GetBytes(message);
            rsa.ImportPkcs8PrivateKey(keyByte, bytesRead: out _);
            byte[] signByte = rsa.SignData(messageByte, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return Convert.ToBase64String(signByte);
        }

        /// <summary>
        /// 生成TOKEN
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <param name="privateKey">私钥</param>
        /// <param name="mchId">商户ID</param>
        /// <param name="serialNo">证书序列号</param>
        /// <returns></returns>
        public static string GenerateToken(string url, string method, string body, string privateKey, string mchId, string serialNo)
        {
            string uri = new Uri(url).PathAndQuery;
            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            string nonce = Guid.NewGuid().ToString("N");
            string message = CreateMessage(uri, method, timestamp, nonce, body);
            string signature = GenerateSign(privateKey, message);
            return $"mchid=\"{mchId}\",nonce_str=\"{nonce}\",timestamp=\"{timestamp}\",serial_no=\"{serialNo}\",signature=\"{signature}\"";
        }

        /// <summary>
        /// 获取通知头
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static NotifyHeader GetNotifyHeader(HttpRequest request)
        {
            NotifyHeader header = new NotifyHeader();
            if (request.Headers.TryGetValue("Wechatpay-Serial", out StringValues serialValues)) { header.SerialNo = serialValues.First() ?? ""; }
            if (request.Headers.TryGetValue("Wechatpay-Timestamp", out StringValues timestampValues)) { header.Timestamp = timestampValues.First() ?? ""; }
            if (request.Headers.TryGetValue("Wechatpay-Nonce", out StringValues nonceValues)) { header.Nonce = nonceValues.First() ?? ""; }
            if (request.Headers.TryGetValue("Wechatpay-Signature", out StringValues signatureValues)) { header.Signature = signatureValues.First() ?? ""; }
            return header;
        }
    }
}
