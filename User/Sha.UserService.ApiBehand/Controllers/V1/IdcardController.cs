using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sha.Common.Extension;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;

namespace Sha.UserService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 身份证
    /// </summary>
    [Authorize(Policy = "OnlyEmployee")]
    [ApiVersion(1.0)]
    public class IdcardController : ShaBaseController
    {
        private readonly IdcardBll bll;

        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="bll">业务逻辑层</param>
        public IdcardController(ILogger<IdcardController> logger, IMapper mapper, IdcardBll bll) : base(logger, mapper)
        {
            this.bll = bll;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">公民身份号码</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_IdentityCard> GetByNumber([FromQuery] string number) => new BaseResponseObject<t_IdentityCard>(true, FrameworkEnum.StatusCode.Success, bll.GetByNumber(number));

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public BaseResponsePage<t_IdentityCard> QueryPage([FromBody] IdcardQueryPage request) => new BaseResponsePage<t_IdentityCard>(true, FrameworkEnum.StatusCode.Success, bll.QueryPage(request), request.TotalNumber);

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public BaseResponse Create([FromBody] IdcardCreate request)
        {
            logger.LogDebug($"身份证新增请求{request.ToJson()}");
            ResultModel<bool> result = bll.Create(request);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
