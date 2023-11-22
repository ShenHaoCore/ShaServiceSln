namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "Jwt";

        /// <summary>
        /// 密钥
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;

        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// 受众人
        /// </summary>
        public string Audience { get; set; } = string.Empty;
    }
}
