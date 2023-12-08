using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace Sha.Business.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class WeChatCertificatesResponse
    {
        [JsonProperty("data")]
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
        [JsonProperty("serial_no")]
        public string SerialNo { get; set; } = string.Empty;

        /// <summary>
        /// 生效时间
        /// </summary>
        [JsonProperty("effective_time")]
        public DateTime EffectiveTime { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        [JsonProperty("expire_time")]
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 加密证书
        /// </summary>
        [JsonProperty("encrypt_certificate")]
        public EncryptCertificate EncryptCertificate { get; set; } = new();
    }

    /// <summary>
    /// 加密证书信息
    /// </summary>
    public class EncryptCertificate
    {
        /// <summary>
        /// 加密算法类型，目前只支持：AEAD_AES_256_GCM
        /// </summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = string.Empty;

        /// <summary>
        /// 随机串
        /// </summary>
        [JsonProperty("nonce")]
        public string Nonce { get; set; } = string.Empty;

        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonProperty("associated_data")]
        public string AssociatedData { get; set; } = string.Empty;

        /// <summary>
        /// 数据密文
        /// </summary>
        [JsonProperty("ciphertext")]
        public string Ciphertext { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class WeChatCertificate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mchid"></param>
        /// <param name="serialno"></param>
        /// <param name="effectivetime"></param>
        /// <param name="expiretime"></param>
        /// <param name="certificate"></param>
        public WeChatCertificate(string mchid, string serialno, DateTime effectivetime, DateTime expiretime, X509Certificate2 certificate)
        {
            this.MchId = mchid;
            this.SerialNo = serialno;
            this.ExpireTime = effectivetime;
            this.ExpireTime = expiretime;
            this.Certificate = certificate;
        }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime EffectiveTime { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 证书
        /// </summary>
        public X509Certificate2 Certificate;
    }
}
