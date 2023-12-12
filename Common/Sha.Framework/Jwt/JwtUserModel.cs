namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtUserModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Uid { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// 职能
        /// </summary>
        public string Work { get; set; } = string.Empty;
    }
}
