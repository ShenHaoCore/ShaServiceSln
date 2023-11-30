using Sha.Framework.Base;

namespace Sha.Business.Payment
{
    /// <summary>
    /// 支付
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        ResultModel<PaymentTradeModel> TradeApp(PaymentTradeParam paramObj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        ResultModel<PaymentTradeModel> TradePage(PaymentTradeParam paramObj);
    }
}
