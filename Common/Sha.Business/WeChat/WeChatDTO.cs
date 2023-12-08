using System.Text.Json.Serialization;

namespace Sha.Business.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class WeChatCertificatesResponse
    {
        [JsonPropertyName("data")]
        public List<Certificate> Certificates { get; set; } = new();
    }

    /// <summary>
    /// 平台证书信息
    /// </summary>
    public class Certificate
    {
        /// <summary>
        /// 序列号
        /// </summary>
        [JsonPropertyName("serial_no")]
        public string SerialNo { get; set; } = string.Empty;

        /// <summary>
        /// 生效时间
        /// </summary>
        [JsonPropertyName("effective_time")]
        public string EffectiveTime { get; set; } = string.Empty;

        /// <summary>
        /// 失效时间
        /// </summary>
        [JsonPropertyName("expire_time")]
        public string ExpireTime { get; set; } = string.Empty;

        /// <summary>
        /// 加密证书
        /// </summary>
        [JsonPropertyName("encrypt_certificate")]
        public EncryptCertificate EncryptCertificate { get; set; } = new();
    }

    /// <summary>
    /// 加密证书信息
    /// </summary>
    public class EncryptCertificate
    {
        /// <summary>
        /// 加密算法类型
        /// </summary>
        [JsonPropertyName("algorithm")]
        public string Algorithm { get; set; } = string.Empty;

        /// <summary>
        /// 随机串
        /// </summary>
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; } = string.Empty;

        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonPropertyName("associated_data")]
        public string AssociatedData { get; set; } = string.Empty;

        /// <summary>
        /// 数据密文
        /// </summary>
        [JsonPropertyName("ciphertext")]
        public string Ciphertext { get; set; } = string.Empty;
    }
}
