using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        #region 变量
        private readonly AccountCathBll bll;
        #endregion

        /// <summary>
        /// 现金账户
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">自动映射</param>
        /// <param name="bll">业务逻辑层</param>
        public AccountCathController(ILogger<AccountCathController> logger, IMapper mapper, AccountCathBll bll) : base(logger, mapper)
        {
            this.bll = bll;
        }

        #region 接口
        /// <summary>
        /// APP充值
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponseObject<RechargeTradeModel> AppRecharge([FromBody] AppRechargeRequest request)
        {
            if (request is null) { return new BaseResponseObject<RechargeTradeModel>(false, FrameworkEnum.StatusCode.RequestNull); }
            logger.LogDebug($"APP充值请求【{JsonConvert.SerializeObject(request)}】");
            RechargeTradeParam paramObj = new RechargeTradeParam(request.Amount, request.Payment);
            ResultModel<RechargeTradeModel> result = bll.AppRecharge(paramObj);
            if (!result.IsSuccess) { return new BaseResponseObject<RechargeTradeModel>(false, result.Code, result.Message); }
            if (result.Data is null) { return new BaseResponseObject<RechargeTradeModel>(false, FrameworkEnum.StatusCode.NotFountData); }
            return new BaseResponseObject<RechargeTradeModel>(true, result.Code, result.Message, result.Data);
        }

        /// <summary>
        /// 网页充值
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponseObject<RechargeTradeModel> PageRecharge([FromBody] PageRechargeRequest request)
        {
            if (request is null) { return new BaseResponseObject<RechargeTradeModel>(false, FrameworkEnum.StatusCode.RequestNull); }
            logger.LogDebug($"网页充值请求【{JsonConvert.SerializeObject(request)}】");
            RechargeTradeParam paramObj = new RechargeTradeParam(request.Amount, request.Payment, request.IsGet ?? false);
            ResultModel<RechargeTradeModel> result = bll.PageRecharge(paramObj);
            if (!result.IsSuccess) { return new BaseResponseObject<RechargeTradeModel>(false, result.Code, result.Message); }
            if (result.Data is null) { return new BaseResponseObject<RechargeTradeModel>(false, FrameworkEnum.StatusCode.NotFountData); }
            return new BaseResponseObject<RechargeTradeModel>(true, result.Code, result.Message, result.Data);
        } 
        #endregion
    }
}
