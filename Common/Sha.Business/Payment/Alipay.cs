using Aop.Api.Domain;
using Aop.Api.Response;
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
            AlipayTradeAppPayModel trade = new AlipayTradeAppPayModel()
            {
                Body = paramObj.Body,
                Subject = paramObj.Subject,
                TotalAmount = paramObj.Amount.ToString(),
                ProductCode = "FAST_INSTANT_TRADE_PAY",
                OutTradeNo = paramObj.TradeNo,
                TimeoutExpress = "90m"
            };
            AlipayTradeAppPayResponse? response = client.TradeAppPay(trade);
            if (response == null || response.IsError) { return new ResultModel<AppPaymentTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<AppPaymentTradeModel>(true, FrameworkEnum.StatusCode.Success, new AppPaymentTradeModel(response.Body));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PagePaymentTradeModel> PageTrade(PagePaymentTradeParam paramObj)
        {
            AlipayTradePagePayModel trade = new AlipayTradePagePayModel()
            {
                Body = paramObj.Body,
                Subject = paramObj.Subject,
                TotalAmount = paramObj.Amount.ToString(),
                ProductCode = "FAST_INSTANT_TRADE_PAY",
                OutTradeNo = paramObj.TradeNo,
                TimeoutExpress = "90m"
            };
            AlipayTradePagePayResponse? response = client.TradePagePay(trade, paramObj.Method);
            if (response == null || response.IsError) { return new ResultModel<PagePaymentTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<PagePaymentTradeModel>(true, FrameworkEnum.StatusCode.Success, new PagePaymentTradeModel(response.Body));
        }
    }
}
