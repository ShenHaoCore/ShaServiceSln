using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Request;

namespace Sha.UserService.Api.Controllers.V1
{
    /// <summary>
    /// 现金账户
    /// </summary>
    [ApiVersion(1.0)]
    public class AccountCathController : ShaBaseController
    {
        private readonly ILogger<AccountCathController> logger;
        private readonly AccountCathBll bll;

        /// <summary>
        /// 现金账户
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="bll"></param>
        public AccountCathController(ILogger<AccountCathController> logger, AccountCathBll bll)
        {
            this.logger = logger;
            this.bll = bll;
        }

        /// <summary>
        /// APP充值
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponseObject<AppRechargeTradeModel> AppRecharge([FromBody] AppRechargeRequest request)
        {
            if (request == null) { return new BaseResponseObject<AppRechargeTradeModel>(false, FrameworkEnum.StatusCode.RequestNull); }
            AppRechargeTradeParam paramObj = new AppRechargeTradeParam(request.Amount, request.PayPlatform);
            ResultModel<AppRechargeTradeModel> result = bll.AppRecharge(paramObj);
            if (!result.IsSuccess) { return new BaseResponseObject<AppRechargeTradeModel>(false, result.Code, result.Message); }
            if (result.Data == null) { return new BaseResponseObject<AppRechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new BaseResponseObject<AppRechargeTradeModel>(true, result.Code, result.Message, result.Data);
        }

        /// <summary>
        /// 网页充值
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponseObject<PageRechargeTradeModel> PageRecharge([FromBody] PageRechargeRequest request)
        {
            if (request == null) { return new BaseResponseObject<PageRechargeTradeModel>(false, FrameworkEnum.StatusCode.RequestNull); }
            PageRechargeTradeParam paramObj = new PageRechargeTradeParam(request.Amount, request.PayPlatform, request.Method);
            ResultModel<PageRechargeTradeModel> result = bll.PageRecharge(paramObj);
            if (!result.IsSuccess) { return new BaseResponseObject<PageRechargeTradeModel>(false, result.Code, result.Message); }
            if (result.Data == null) { return new BaseResponseObject<PageRechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new BaseResponseObject<PageRechargeTradeModel>(true, result.Code, result.Message, result.Data);
        }
    }
}
