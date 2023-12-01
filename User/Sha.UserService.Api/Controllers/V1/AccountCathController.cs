﻿using Asp.Versioning;
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
        public BaseResponseObject<RechargeTradeModel> AppRecharge([FromBody] RechargeRequest request)
        {
            if (request == null) { return new BaseResponseObject<RechargeTradeModel>(false, FrameworkEnum.StatusCode.RequestNull); }
            RechargeTradeParam paramObj = new RechargeTradeParam(request.Amount, request.PayPlatform, request.Method);
            ResultModel<RechargeTradeModel> result = bll.AppRecharge(paramObj);
            if (!result.IsSuccess) { return new BaseResponseObject<RechargeTradeModel>(false, result.Code, result.Message); }
            if (result.Data == null) { return new BaseResponseObject<RechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new BaseResponseObject<RechargeTradeModel>(true, result.Code, result.Message, result.Data);
        }

        /// <summary>
        /// 网页充值
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponseObject<RechargeTradeModel> PageRecharge([FromBody] RechargeRequest request)
        {
            if (request == null) { return new BaseResponseObject<RechargeTradeModel>(false, FrameworkEnum.StatusCode.RequestNull); }
            RechargeTradeParam paramObj = new RechargeTradeParam(request.Amount, request.PayPlatform, request.Method);
            ResultModel<RechargeTradeModel> result = bll.PageRecharge(paramObj);
            if (!result.IsSuccess) { return new BaseResponseObject<RechargeTradeModel>(false, result.Code, result.Message); }
            if (result.Data == null) { return new BaseResponseObject<RechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new BaseResponseObject<RechargeTradeModel>(true, result.Code, result.Message, result.Data);
        }
    }
}
