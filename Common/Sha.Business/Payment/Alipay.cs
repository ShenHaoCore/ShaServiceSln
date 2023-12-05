using Aop.Api.Domain;
using Aop.Api.Response;
using Sha.Business.Alipay;
using Sha.Business.Enum;
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

        public readonly string TimeoutExpress = "90m";
        public readonly string ProductCode = "FAST_INSTANT_TRADE_PAY";

        /// <summary>
        /// APP交易
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PaymentTradeOrder> AppTrade(PaymentTrade paramObj)
        {
            AlipayTradeAppPayModel trade = new AlipayTradeAppPayModel() { Body = paramObj.Body, Subject = paramObj.Subject, TotalAmount = paramObj.Amount.ToString(), OutTradeNo = paramObj.TradeNo };
            trade.ProductCode = ProductCode;
            trade.TimeoutExpress = TimeoutExpress;
            AlipayTradeAppPayResponse? response = client.TradeAppPay(trade);
            if (response == null || response.IsError) { return new ResultModel<PaymentTradeOrder>(false, FrameworkEnum.StatusCode.ResponseError); }
            return new ResultModel<PaymentTradeOrder>(true, FrameworkEnum.StatusCode.Success, new PaymentTradeOrder(response.Body));
        }

        /// <summary>
        /// 网页交易
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PaymentTradeOrder> PageTrade(PaymentTrade paramObj)
        {
            AlipayTradePagePayModel trade = new AlipayTradePagePayModel() { Body = paramObj.Body, Subject = paramObj.Subject, TotalAmount = paramObj.Amount.ToString(), OutTradeNo = paramObj.TradeNo };
            trade.ProductCode = ProductCode;
            trade.TimeoutExpress = TimeoutExpress;
            BusinessEnum.RequestMethod method = BusinessEnum.RequestMethod.POST; // POST方式请求，生成FORM表单
            if (paramObj.IsGet == true) { method = BusinessEnum.RequestMethod.GET; } // GET方式请求，即生成URL链接;
            AlipayTradePagePayResponse? response = client.TradePagePay(trade, method);
            if (response == null || response.IsError) { return new ResultModel<PaymentTradeOrder>(false, FrameworkEnum.StatusCode.ResponseError); }
            return new ResultModel<PaymentTradeOrder>(true, FrameworkEnum.StatusCode.Success, new PaymentTradeOrder(response.Body));
        }
    }
}
