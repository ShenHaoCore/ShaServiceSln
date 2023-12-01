using Aop.Api.Domain;
using Aop.Api.Response;
using Sha.Business.Alipay;
using Sha.Business.Enum;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using static Sha.Business.Enum.BusinessEnum;

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
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<AppPaymentTradeModel> AppTrade(AppPaymentTradeParam paramObj)
        {
            AlipayTradeAppPayModel trade = new AlipayTradeAppPayModel() { Body = paramObj.Body, Subject = paramObj.Subject, TotalAmount = paramObj.Amount.ToString(), ProductCode = ProductCode, OutTradeNo = paramObj.TradeNo, TimeoutExpress = TimeoutExpress };
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
            AlipayTradePagePayModel trade = new AlipayTradePagePayModel() { Body = paramObj.Body, Subject = paramObj.Subject, TotalAmount = paramObj.Amount.ToString(), ProductCode = ProductCode, OutTradeNo = paramObj.TradeNo, TimeoutExpress = TimeoutExpress };
            BusinessEnum.RequestMethod method = BusinessEnum.RequestMethod.POST; // POST方式请求，生成FORM表单
            if (paramObj.Method.Equals(BusinessEnum.RequestMethod.GET.ToString(), StringComparison.OrdinalIgnoreCase)) { method = BusinessEnum.RequestMethod.GET; } // GET方式请求，即生成URL链接;
            AlipayTradePagePayResponse? response = client.TradePagePay(trade, method);
            if (response == null || response.IsError) { return new ResultModel<PagePaymentTradeModel>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<PagePaymentTradeModel>(true, FrameworkEnum.StatusCode.Success, new PagePaymentTradeModel(response.Body));
        }
    }
}
