using Aop.Api.Domain;
using Autofac;
using Sha.Business.Enum;
using Sha.Business.Payment;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.UserService.Bll.Common;
using Sha.UserService.Model.DTO;

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
        public ResultModel<RechargeTradeModel> AppRecharge(RechargeTradeParam paramObj)
        {
            if (!Enum.IsDefined(typeof(BusinessEnum.Payment), paramObj.Payment)) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            IPayment iPay = context.ResolveKeyed<IPayment>((BusinessEnum.Payment)paramObj.Payment);
            string tradeNo = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            PaymentTradeParam trade = new PaymentTradeParam("支付充值", $"账户充值{paramObj.Amount.ToString("f2")}元", paramObj.Amount, tradeNo, paramObj.Method);
            ResultModel<PaymentTradeModel> payResult = iPay.TradeApp(trade);
            if (!payResult.IsSuccess) { return new ResultModel<RechargeTradeModel>(false, payResult.Code, payResult.Message); }
            if (payResult.Data == null) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new ResultModel<RechargeTradeModel>(true, FrameworkEnum.StatusCode.Success, new RechargeTradeModel(payResult.Data.Body));
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns></returns>
        public ResultModel<RechargeTradeModel> PageRecharge(RechargeTradeParam paramObj)
        {
            if (!Enum.IsDefined(typeof(BusinessEnum.Payment), paramObj.Payment)) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            IPayment iPay = context.ResolveKeyed<IPayment>((BusinessEnum.Payment)paramObj.Payment);
            string tradeNo = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            PaymentTradeParam trade = new PaymentTradeParam("支付充值", $"账户充值{paramObj.Amount.ToString("f2")}元", paramObj.Amount, tradeNo, paramObj.Method);
            ResultModel<PaymentTradeModel> payResult = iPay.TradePage(trade);
            if (!payResult.IsSuccess) { return new ResultModel<RechargeTradeModel>(false, payResult.Code, payResult.Message); }
            if (payResult.Data == null) { return new ResultModel<RechargeTradeModel>(false, FrameworkEnum.StatusCode.NoData); }
            return new ResultModel<RechargeTradeModel>(true, FrameworkEnum.StatusCode.Success, new RechargeTradeModel(payResult.Data.Body));
        }
        #endregion
    }
}
