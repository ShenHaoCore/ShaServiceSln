using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sha.UserService.Model.DTO
{
    /// <summary>
    /// 员工登录
    /// </summary>
    public class EmployeeLogin
    {
        /// <summary>
        /// 员工登录
        /// </summary>
        /// <param name="number">工号</param>
        /// <param name="password">密码</param>
        public EmployeeLogin(string number, string password)
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
    /// 员工登录验证
    /// </summary>
    public class EmployeeLoginValidator : AbstractValidator<EmployeeLogin>
    {
        /// <summary>
        /// 员工登录验证
        /// </summary>
        public EmployeeLoginValidator()
        {
            RuleFor(it => it.Number).NotEmpty().WithName("工号");
            RuleFor(it => it.Password).NotEmpty().MinimumLength(6).WithName("密码");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="token"></param>
        public LoginModel(string type, string token)
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

    /// <summary>
    /// 
    /// </summary>
    public class EmployeeCreate
    {
        /// <summary>
        /// 
        /// </summary>
        public EmployeeCreate(string number, string password)
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
    /// 员工新建验证
    /// </summary>
    public class EmployeeCreateValidator : AbstractValidator<EmployeeCreate>
    {
        /// <summary>
        /// 员工登录验证
        /// </summary>
        public EmployeeCreateValidator()
        {
            RuleFor(it => it.Number).NotEmpty().WithName("工号").WithMessage("{PropertyName}不能为空");
            RuleFor(it => it.Password).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("{PropertyName}不能为空").MinimumLength(6).WithName("密码").WithMessage("{PropertyName}长度小于{MinLength}");
        }
    }
}
