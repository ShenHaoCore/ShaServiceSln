using FluentValidation;

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
            RuleFor(it => it.Number).NotEmpty().WithMessage("{PropertyName}不能为空").WithName("工号");
            RuleFor(it => it.Password).NotEmpty().WithMessage("{PropertyName}不能为空").WithName("密码");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmployeeCreate
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = string.Empty;
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
            RuleFor(it => it.Number).NotEmpty().WithMessage("{PropertyName}不能为空").WithName("工号");
            RuleFor(it => it.Password).NotEmpty().WithMessage("{PropertyName}不能为空").WithName("密码");
            RuleFor(it => it.Name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("{PropertyName}不能为空").MaximumLength(10).WithMessage("{PropertyName}长度大于{MaxLength}").WithName("姓名");
        }
    }
}
