using Sha.Business.Alipay;
using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.Business.Payment
{
    /// <summary>
    /// 支付宝
    /// </summary>
    public class Alipay : IPayment
    {
        public readonly IAlipayClient client;

        /// <summary>
        /// 支付宝
        /// </summary>
        /// <param name="client">客户端</param>
        public Alipay(IAlipayClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<AppPaymentTradeModel> AppTrade(AppPaymentTradeParam paramObj)
        {
            TradeAppParam trade = new TradeAppParam(paramObj.Amount.ToString(), paramObj.Body, paramObj.Subject, paramObj.TradeNo);
            ResultModel<TradeAppOrder> result = client.TradeAppPay(trade);
            if (!result.IsSuccess || result.Data == null) { return new ResultModel<AppPaymentTradeModel>(false, result.Code, result.Message); }
            return new ResultModel<AppPaymentTradeModel>(true, FrameworkEnum.StatusCode.Success, new AppPaymentTradeModel(result.Data.Body));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PagePaymentTradeModel> PageTrade(PagePaymentTradeParam paramObj)
        {
            TradePageParam trade = new TradePageParam(paramObj.Amount.ToString(), paramObj.Body, paramObj.Subject, paramObj.TradeNo, paramObj.Method);
            ResultModel<TradePageOrder> result = client.TradePagePay(trade);
            if (!result.IsSuccess || result.Data == null) { return new ResultModel<PagePaymentTradeModel>(false, result.Code, result.Message); }
            return new ResultModel<PagePaymentTradeModel>(true, FrameworkEnum.StatusCode.Success, new PagePaymentTradeModel(result.Data.Body));
        }
    }
}
