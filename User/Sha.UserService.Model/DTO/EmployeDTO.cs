namespace Sha.UserService.Model.DTO
{
    /// <summary>
    /// 员工登录
    /// </summary>
    public class EmployeLoginParam
    {
        /// <summary>
        /// 员工登录
        /// </summary>
        /// <param name="number">工号</param>
        /// <param name="password">密码</param>
        public EmployeLoginParam(string number, string password)
        {
            this.Number = number;
            this.Password = password;
        }

        /// <summary>
        /// 工号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmployeLoginModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="token"></param>
        public EmployeLoginModel(string type,string token)
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
