using Autofac;
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
        public AccountCathBll(IComponentContext context)
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
            if (!Enum.IsDefined(typeof(BusinessEnum.PayPlatform), paramObj.PayPlatform)) { return new ResultModel<AppRechargeTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            IPayment iPay = context.ResolveKeyed<IPayment>((BusinessEnum.PayPlatform)paramObj.PayPlatform);
            t_RechargeTrade recharge = new t_RechargeTrade() { TradeNo = DateTime.Now.ToString("yyyyMMddHHmmssfff") };
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
            if (!Enum.IsDefined(typeof(BusinessEnum.PayPlatform), paramObj.PayPlatform)) { return new ResultModel<PageRechargeTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            IPayment iPay = context.ResolveKeyed<IPayment>((BusinessEnum.PayPlatform)paramObj.PayPlatform);
            string tradeNo = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            PagePaymentTradeParam trade = new PagePaymentTradeParam("支付充值", $"账户充值{paramObj.Amount.ToString("f2")}元", paramObj.Amount, tradeNo, paramObj.Method);
            ResultModel<PagePaymentTradeOrder> payResult = iPay.PageTrade(trade);
            if (!payResult.IsSuccess) { return new ResultModel<PageRechargeTradeModel>(false, payResult.Code, payResult.Message); }
            if (payResult.Data == null) { return new ResultModel<PageRechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new ResultModel<PageRechargeTradeModel>(true, FrameworkEnum.StatusCode.Success, new PageRechargeTradeModel(payResult.Data.Body));
        }
        #endregion
    }
}
