using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.Framework.Jwt;
using Sha.UserService.Bll;
using Sha.UserService.Model.DTO;

namespace Sha.UserService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 职员
    /// </summary>
    [Authorize]
    [ApiVersion(1.0)]
    public class EmployeController : ShaBaseController
    {
        private readonly ILogger<EmployeController> logger;
        private readonly EmployeBll bll;

        /// <summary>
        /// 职员
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="bll">业务逻辑层</param>
        public EmployeController(ILogger<EmployeController> logger, EmployeBll bll)
        {
            this.logger = logger;
            this.bll = bll;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public BaseResponseObject<EmployeLoginModel> Login()
        {
            EmployeLoginModel login = new EmployeLoginModel(JwtHelper.IssueToken(new JwtUserModel() { Uid = 1000 }));
            return new BaseResponseObject<EmployeLoginModel>(true, FrameworkEnum.StatusCode.Success, login);
        }
    }
}
