using Autofac;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sha.Business.Common;
using Sha.Business.Enum;
using Sha.Business.Payment;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll.Common;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;

namespace Sha.UserService.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountCathBll : UserServiceBll
    {
        #region 变量
        private readonly IComponentContext context;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountCathBll(ILogger<IdentityCardBll> logger, IComponentContext context) : base(logger)
        {
            this.context = context;
        }

        #region 方法
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns></returns>
        public ResultModel<AppRechargeTradeModel> AppRecharge(AppRechargeTradeParam paramObj)
        {
            logger.LogDebug($"APP充值请求【{JsonConvert.SerializeObject(paramObj)}】");
            AppRechargeTradeValidator validator = new AppRechargeTradeValidator();
            ValidationResult validResult = validator.Validate(paramObj);
            if (!validResult.IsValid) { return new ResultModel<AppRechargeTradeModel>(false, FrameworkEnum.StatusCode.ValidateFail); }
            IPayment iPay = context.ResolveKeyed<IPayment>((BusinessEnum.Payment)paramObj.Payment);
            t_RechargeTrade recharge = new t_RechargeTrade(OrderHelper.GetOrderNo(BusinessEnum.BusinessType.RE), paramObj.Amount, (int)BusinessEnum.Currency.CNY, paramObj.Payment);
            AppPaymentTradeParam trade = new AppPaymentTradeParam("支付充值", $"账户充值{recharge.Amount.ToString("f2")}元", recharge.Amount, recharge.TradeNo);
            ResultModel<AppPaymentTradeOrder> payResult = iPay.AppTrade(trade);
            if (!payResult.IsSuccess) { return new ResultModel<AppRechargeTradeModel>(false, payResult.Code, payResult.Message); }
            if (payResult.Data == null) { return new ResultModel<AppRechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new ResultModel<AppRechargeTradeModel>(true, FrameworkEnum.StatusCode.Success, new AppRechargeTradeModel(payResult.Data.Body));
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns></returns>
        public ResultModel<PageRechargeTradeModel> PageRecharge(PageRechargeTradeParam paramObj)
        {
            logger.LogDebug($"网页充值请求【{JsonConvert.SerializeObject(paramObj)}】");
            PageRechargeTradeValidator validator = new PageRechargeTradeValidator();
            ValidationResult validResult = validator.Validate(paramObj);
            if (!validResult.IsValid) { return new ResultModel<PageRechargeTradeModel>(false, FrameworkEnum.StatusCode.ValidateFail); }
            IPayment iPay = context.ResolveKeyed<IPayment>((BusinessEnum.Payment)paramObj.Payment);
            t_RechargeTrade recharge = new t_RechargeTrade(OrderHelper.GetOrderNo(BusinessEnum.BusinessType.RE), paramObj.Amount, (int)BusinessEnum.Currency.CNY, paramObj.Payment);
            PagePaymentTradeParam trade = new PagePaymentTradeParam("支付充值", $"账户充值{paramObj.Amount.ToString("f2")}元", paramObj.Amount, recharge.TradeNo, paramObj.Method);
            ResultModel<PagePaymentTradeOrder> payResult = iPay.PageTrade(trade);
            if (!payResult.IsSuccess) { return new ResultModel<PageRechargeTradeModel>(false, payResult.Code, payResult.Message); }
            if (payResult.Data == null) { return new ResultModel<PageRechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new ResultModel<PageRechargeTradeModel>(true, FrameworkEnum.StatusCode.Success, new PageRechargeTradeModel(payResult.Data.Body));
        }
        #endregion
    }
}
