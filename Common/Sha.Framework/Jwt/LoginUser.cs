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
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        public LoginUser(int userId, FrameworkEnum.UserType userType)
        {
            this.UserID = userId;
            this.UserType = userType;
        }

        /// <summary>
        /// 
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FrameworkEnum.UserType UserType { get; set; }
    }
}
