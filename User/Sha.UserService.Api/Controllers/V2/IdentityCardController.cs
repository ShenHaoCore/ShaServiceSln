using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;
using Sha.UserService.Model.Request;

namespace Sha.UserService.Api.Controllers.V2
{
    /// <summary>
    /// 身份证
    /// </summary>
    [ApiVersion(2.0)]
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
        public BaseResponse Create([FromBody] IdcardCreateRequest request)
        {
            logger.LogDebug($"身份证新增请求{JsonConvert.SerializeObject(request)}");
            IdcardCreateParam param = ConvertTo(request);
            ResultModel<bool> result = bll.Create(param);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }

        #region 转型
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private IdcardCreateParam ConvertTo(IdcardCreateRequest request)
        {
            IdcardCreateParam param = new IdcardCreateParam()
            {
                Name = request.Name
            };
            return param;
        }
        #endregion
    }
}
