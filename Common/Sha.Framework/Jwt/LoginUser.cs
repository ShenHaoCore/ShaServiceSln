using Sha.Framework.Enum;

namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FrameworkEnum.UserType UserType { get; set; }
    }
}
