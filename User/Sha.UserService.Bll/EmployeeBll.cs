using AutoMapper;
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
        /// <param name="mapper">映射</param>
        /// <param name="redis"></param>
        /// <param name="dal">数据访问层</param>
        public EmployeeBll(ILogger<EmployeeBll> logger, IMapper mapper, IRedisManage redis, EmployeeDal dal) : base(logger, mapper)
        {
            this.redis = redis;
            this.dal = dal;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public t_Employee GetById(int id) => dal.GetById(id);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">工号</param>
        /// <returns></returns>
        public t_Employee GetByNumber(string number) => dal.GetByNumber(number);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns></returns>
        public ResultModel<LoginResult> Login(EmployeeLogin paramObj)
        {
            EmployeeLoginValidator validator = new EmployeeLoginValidator();
            ValidationResult validResult = validator.Validate(paramObj);
            if (!validResult.IsValid) { return new ResultModel<LoginResult>(false, FrameworkEnum.StatusCode.ValidateFail); }
            t_Employee employee = dal.GetByNumber(paramObj.Number);
            if (employee is null) { return new ResultModel<LoginResult>(false, FrameworkEnum.StatusCode.UserNotExists); }
            TokenInfoModel info = new TokenInfoModel() { UserID = employee.ID, UserType = FrameworkEnum.UserType.Employee.ToString() };
            LoginResult login = new LoginResult(JwtHelper.Type, JwtHelper.GenerateToken(info));
            LoginInfoModel empuser = new LoginInfoModel(employee.ID, FrameworkEnum.UserType.Employee);
            if (!redis.Set($"{FrameworkEnum.UserType.Employee.ToString().ToUpper()}-{info.UserID}", empuser, JwtHelper.Expiry)) { return new ResultModel<LoginResult>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<LoginResult>(true, FrameworkEnum.StatusCode.Success, login);
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns></returns>
        public ResultModel<bool> Create(EmployeeCreate paramObj)
        {
            EmployeeCreateValidator validator = new EmployeeCreateValidator();
            ValidationResult validResult = validator.Validate(paramObj);
            if (!validResult.IsValid) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.ValidateFail); }
            t_Employee employee = dal.GetByNumber(paramObj.Number);
            if (employee is not null) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.RepeatNumber); }
            employee = mapper.Map<t_Employee>(paramObj);
            if (!dal.Create(employee)) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<bool>(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
