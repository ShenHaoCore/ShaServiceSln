using Autofac;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sha.Business.Common;
using Sha.Business.Enum;
using Sha.Business.Payment;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll.Common;
using Sha.UserService.Dal;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;

namespace Sha.UserService.Bll
{
    /// <summary>
    /// 现金账户
    /// </summary>
    public class AccountCathBll : UserServiceBll
    {
        #region 变量
        private readonly IComponentContext context;
        private readonly AccountCathDal dal;
        #endregion

        /// <summary>
        /// 现金账户
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">自动映射</param>
        /// <param name="dal">数据访问层</param>
        /// <param name="context"></param>
        public AccountCathBll(ILogger<IdcardBll> logger, IMapper mapper, AccountCathDal dal, IComponentContext context) : base(logger, mapper)
        {
            this.dal = dal;
            this.context = context;
        }

        #region 方法
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns></returns>
        public ResultModel<RechargeTradeModel> AppRecharge(RechargeTradeParam paramObj)
        {
            logger.LogDebug($"APP充值请求【{JsonConvert.SerializeObject(paramObj)}】");
            RechargeTradeValidator validator = new RechargeTradeValidator();
            ValidationResult validResult = validator.Validate(paramObj);
            if (!validResult.IsValid) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.ValidateFail); }
            IPayment iPay = context.ResolveKeyed<IPayment>((BusinessEnum.Payment)paramObj.Payment);
            var recharge = CreateTrade(paramObj);
            if (recharge == null) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            PaymentTrade trade = new PaymentTrade("支付充值", $"账户充值{recharge.Amount.ToString("f2")}元", recharge.Amount, recharge.TradeNo);
            ResultModel<PaymentTradeOrder> payResult = iPay.AppTrade(trade);
            if (!payResult.IsSuccess) { return new ResultModel<RechargeTradeModel>(false, payResult.Code, payResult.Message); }
            if (payResult.Data == null) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.NotFountData); }
            return new ResultModel<RechargeTradeModel>(true, FrameworkEnum.StatusCode.Success, new RechargeTradeModel(payResult.Data.Body));
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns></returns>
        public ResultModel<RechargeTradeModel> PageRecharge(RechargeTradeParam paramObj)
        {
            logger.LogDebug($"网页充值请求【{JsonConvert.SerializeObject(paramObj)}】");
            RechargeTradeValidator validator = new RechargeTradeValidator();
            ValidationResult validResult = validator.Validate(paramObj);
            if (!validResult.IsValid) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.ValidateFail); }
            IPayment iPay = context.ResolveKeyed<IPayment>((BusinessEnum.Payment)paramObj.Payment);
            var recharge = CreateTrade(paramObj);
            if (recharge == null) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            PaymentTrade trade = new PaymentTrade("支付充值", $"账户充值{recharge.Amount.ToString("f2")}元", recharge.Amount, recharge.TradeNo, paramObj.IsGet);
            ResultModel<PaymentTradeOrder> payResult = iPay.PageTrade(trade);
            if (!payResult.IsSuccess) { return new ResultModel<RechargeTradeModel>(false, payResult.Code, payResult.Message); }
            if (payResult.Data == null) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.NotFountData); }
            return new ResultModel<RechargeTradeModel>(true, FrameworkEnum.StatusCode.Success, new RechargeTradeModel(payResult.Data.Body));
        }

        /// <summary>
        /// 创建交易
        /// </summary>
        /// <param name="paramObj">參數</param>
        /// <returns></returns>
        public t_RechargeTrade? CreateTrade(RechargeTradeParam paramObj)
        {
            t_RechargeTrade recharge = new t_RechargeTrade(OrderHelper.GetOrderNo(BusinessEnum.BusinessType.RE), paramObj.Amount, (int)BusinessEnum.Currency.CNY, paramObj.Payment);
            if (!dal.CreateTrade(recharge)) { return null; }
            return recharge;
        }
        #endregion
    }
}
