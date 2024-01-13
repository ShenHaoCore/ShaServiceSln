using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;
using Sha.UserService.Model.Request;

namespace Sha.UserService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 身份证
    /// </summary>
    [Authorize(Policy = "OnlyEmployee")]
    [ApiVersion(1.0)]
    public class IdentityCardController : ShaBaseController
    {
        private readonly IdentityCardBll bll;

        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="bll">业务逻辑层</param>
        public IdentityCardController(ILogger<IdentityCardController> logger, IdentityCardBll bll) : base(logger)
        {
            this.bll = bll;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">公民身份号码</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_IdentityCard> GetByNumber([FromQuery] string number)
        {
            return new BaseResponseObject<t_IdentityCard>(true, FrameworkEnum.StatusCode.Success, bll.GetByNumber(number));
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Create([FromBody] IdcardCreate request)
        {
            logger.LogDebug($"身份证新增请求{JsonConvert.SerializeObject(request)}");
            ResultModel<bool> result = bll.Create(request);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public BaseResponsePage<t_IdentityCard> QueryPage([FromBody] IdcardPageQuery request)
        {
            List<t_IdentityCard> cards = bll.QueryPage(request);
            return new BaseResponsePage<t_IdentityCard>(true, FrameworkEnum.StatusCode.Success, cards, request.TotalNumber);
        }
    }
}
