using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.Framework.Jwt;
using Sha.Framework.Redis;
using Sha.UserService.Bll.Common;
using Sha.UserService.Dal;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;

namespace Sha.UserService.Bll
{
    /// <summary>
    /// 员工
    /// </summary>
    public class EmployeeBll : UserServiceBll
    {
        private readonly IRedisManage redis;
        private readonly EmployeeDal dal;

        /// <summary>
        /// 员工
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="redis"></param>
        /// <param name="dal">数据访问层</param>
        public EmployeeBll(ILogger<EmployeeBll> logger, IRedisManage redis, EmployeeDal dal) : base(logger)
        {
            this.redis = redis;
            this.dal = dal;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public ResultModel<LoginModel> Login(EmployeeLogin param)
        {
            EmployeeLoginValidator validator = new EmployeeLoginValidator();
            ValidationResult validResult = validator.Validate(param);
            if (!validResult.IsValid) { return new ResultModel<LoginModel>(false, FrameworkEnum.StatusCode.ValidateFail); }
            t_Employee employee = dal.GetByNumber(param.Number);
            if (employee == null) { return new ResultModel<LoginModel>(false, FrameworkEnum.StatusCode.UserNotFount); }
            JwtUserModel user = new JwtUserModel() { Uid = employee.ID, Role = "Employee" };
            LoginModel login = new LoginModel(JwtHelper.Type, JwtHelper.IssueToken(user));
            EmployeeUser empUser = new EmployeeUser() { ID = employee.ID };
            if (!redis.Set($"EMPLOYEE-{user.Uid}", empUser, new TimeSpan(0, 30, 0))) { return new ResultModel<LoginModel>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<LoginModel>(true, FrameworkEnum.StatusCode.Success, login);
        }
    }
}
