using Microsoft.Extensions.Logging;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.Framework.Jwt;
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
        private readonly ILogger<EmployeeBll> logger;
        private readonly EmployeeDal dal;

        /// <summary>
        /// 员工
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="dal">数据访问层</param>
        public EmployeeBll(ILogger<EmployeeBll> logger, EmployeeDal dal)
        {
            this.logger = logger;
            this.dal = dal;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public ResultModel<EmployeLoginModel> Login(EmployeLoginParam param)
        {
            t_Employee employee = dal.GetByNumber(param.Number);
            if (employee == null) { return new ResultModel<EmployeLoginModel>(false, FrameworkEnum.StatusCode.UserNotFount); }
            JwtUserModel user = new JwtUserModel() { Uid = employee.ID, Role = "Employee" };
            EmployeLoginModel login = new EmployeLoginModel(JwtHelper.Type, JwtHelper.IssueToken(user));
            return new ResultModel<EmployeLoginModel>(true, FrameworkEnum.StatusCode.Success, login);
        }
    }
}
