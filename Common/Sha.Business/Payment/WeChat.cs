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
        public ResultModel<PaymentTradeOrder> AppTrade(PaymentTrade paramObj)
        {
            return new ResultModel<PaymentTradeOrder>(false, FrameworkEnum.StatusCode.NoService);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PaymentTradeOrder> PageTrade(PaymentTrade paramObj)
        {
            return new ResultModel<PaymentTradeOrder>(false, FrameworkEnum.StatusCode.NoService);
        }
    }
}
