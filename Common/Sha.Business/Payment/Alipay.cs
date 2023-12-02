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

        /// <summary>
        /// 
        /// </summary>
        public string TimeoutExpress { get; set; } = "90m";

        /// <summary>
        /// 
        /// </summary>
        public string ProductCode { get; set; } = "FAST_INSTANT_TRADE_PAY";

        /// <summary>
        /// APP交易
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<AppPaymentTradeOrder> AppTrade(AppPaymentTradeParam paramObj)
        {
            AlipayTradeAppPayModel trade = new AlipayTradeAppPayModel() { Body = paramObj.Body, Subject = paramObj.Subject, TotalAmount = paramObj.Amount.ToString(), OutTradeNo = paramObj.TradeNo };
            trade.ProductCode = ProductCode;
            trade.TimeoutExpress = TimeoutExpress;
            AlipayTradeAppPayResponse? response = client.TradeAppPay(trade);
            if (response == null || response.IsError) { return new ResultModel<AppPaymentTradeOrder>(false, FrameworkEnum.StatusCode.ResponseError); }
            return new ResultModel<AppPaymentTradeOrder>(true, FrameworkEnum.StatusCode.Success, new AppPaymentTradeOrder(response.Body));
        }

        /// <summary>
        /// 网页交易
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PagePaymentTradeOrder> PageTrade(PagePaymentTradeParam paramObj)
        {
            AlipayTradePagePayModel trade = new AlipayTradePagePayModel() { Body = paramObj.Body, Subject = paramObj.Subject, TotalAmount = paramObj.Amount.ToString(), OutTradeNo = paramObj.TradeNo };
            trade.ProductCode = ProductCode;
            trade.TimeoutExpress = TimeoutExpress;
            BusinessEnum.RequestMethod method = BusinessEnum.RequestMethod.POST; // POST方式请求，生成FORM表单
            if (paramObj.Method.Equals(BusinessEnum.RequestMethod.GET.ToString(), StringComparison.OrdinalIgnoreCase)) { method = BusinessEnum.RequestMethod.GET; } // GET方式请求，即生成URL链接;
            AlipayTradePagePayResponse? response = client.TradePagePay(trade, method);
            if (response == null || response.IsError) { return new ResultModel<PagePaymentTradeOrder>(false, FrameworkEnum.StatusCode.ResponseError); }
            return new ResultModel<PagePaymentTradeOrder>(true, FrameworkEnum.StatusCode.Success, new PagePaymentTradeOrder(response.Body));
        }
    }
}
