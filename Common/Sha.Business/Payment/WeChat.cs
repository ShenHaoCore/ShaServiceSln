using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.Business.Payment
{
    /// <summary>
    /// 微信
    /// </summary>
    public class WeChat : IPayment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PaymentTradeModel> TradeApp(PaymentTradeParam paramObj)
        {
            return new ResultModel<PaymentTradeModel>(false, FrameworkEnum.StatusCode.NoService);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PaymentTradeModel> TradePage(PaymentTradeParam paramObj)
        {
            return new ResultModel<PaymentTradeModel>(false, FrameworkEnum.StatusCode.NoService);
        }
    }
}
