using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.Framework.Jwt;
using Sha.UserService.Bll;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;

namespace Sha.UserService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 员工
    /// </summary>
    [Authorize]
    [ApiVersion(1.0)]
    public class EmployeeController : ShaBaseController
    {
        private readonly EmployeeBll bll;

        /// <summary>
        /// 员工
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">自动映射</param>
        /// <param name="bll">业务逻辑层</param>
        public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper, EmployeeBll bll) : base(logger, mapper)
        {
            this.bll = bll;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_Employee> GetById([FromQuery] int id) => new BaseResponseObject<t_Employee>(true, FrameworkEnum.StatusCode.Success, bll.GetById(id));

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">工号</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_Employee> GetByNumber([FromQuery] string number) => new BaseResponseObject<t_Employee>(true, FrameworkEnum.StatusCode.Success, bll.GetByNumber(number));

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public BaseResponseObject<LoginResult> Login([FromBody] EmployeeLogin request)
        {
            ResultModel<LoginResult> result = bll.Login(request);
            if (!result.IsSuccess) { return new BaseResponseObject<LoginResult>(false, result.Code, result.Message); }
            return new BaseResponseObject<LoginResult>(true, FrameworkEnum.StatusCode.Success, result.Data);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public BaseResponse Create([FromBody] EmployeeCreate request)
        {
            ResultModel<bool> result = bll.Create(request);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
