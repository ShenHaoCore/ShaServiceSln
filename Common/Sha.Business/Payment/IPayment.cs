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
        ResultModel<AppPaymentTradeModel> AppTrade(AppPaymentTradeParam paramObj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        ResultModel<PagePaymentTradeModel> PageTrade(PagePaymentTradeParam paramObj);
    }
}
