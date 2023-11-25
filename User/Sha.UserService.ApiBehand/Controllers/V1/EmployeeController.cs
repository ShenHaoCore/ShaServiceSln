using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Request;

namespace Sha.UserService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 员工
    /// </summary>
    [Authorize]
    [ApiVersion(1.0)]
    public class EmployeeController : ShaBaseController
    {
        private readonly ILogger<EmployeeController> logger;
        private readonly EmployeeBll bll;

        /// <summary>
        /// 员工
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="bll">业务逻辑层</param>
        public EmployeeController(ILogger<EmployeeController> logger, EmployeeBll bll)
        {
            this.logger = logger;
            this.bll = bll;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public BaseResponseObject<EmployeLoginModel> Login([FromBody] EmployeLoginRequest request)
        {
            EmployeLoginParam param = new EmployeLoginParam(request.Number, request.Password);
            ResultModel<EmployeLoginModel> result = bll.Login(param);
            if (!result.IsSuccess) { return new BaseResponseObject<EmployeLoginModel>(false, result.Code, result.Message); }
            return new BaseResponseObject<EmployeLoginModel>(true, FrameworkEnum.StatusCode.Success, result.Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Create()
        {
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
