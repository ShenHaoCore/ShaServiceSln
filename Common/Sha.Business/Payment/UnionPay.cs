using Aop.Api.Domain;
using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.Business.Payment
{
    /// <summary>
    /// 银联
    /// </summary>
    public class UnionPay : IPayment
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
