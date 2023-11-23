namespace Sha.UserService.Model.Request
{
    /// <summary>
    /// 员工登录请求
    /// </summary>
    public class EmployeLoginRequest
    {
        /// <summary>
        /// 员工登录请求
        /// </summary>
        public EmployeLoginRequest()
        {
            this.Number = string.Empty;
            this.Password = string.Empty;
        }

        /// <summary>
        /// 员工登录请求
        /// </summary>
        /// <param name="number">工号</param>
        /// <param name="password">密码</param>
        public EmployeLoginRequest(string number, string password)
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
}
