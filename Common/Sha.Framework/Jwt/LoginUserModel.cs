using Sha.Framework.Enum;

namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginUserModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; } = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// 职能
        /// </summary>
        public string Work { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        public LoginModel(int userId, FrameworkEnum.UserType userType)
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

    /// <summary>
    /// 
    /// </summary>
    public class LoginResultModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="token"></param>
        public LoginResultModel(string type, string token)
        {
            this.Type = type;
            this.Token = token;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }
    }
}
