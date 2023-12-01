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
        public ResultModel<AppPaymentTradeOrder> AppTrade(AppPaymentTradeParam paramObj)
        {
            return new ResultModel<AppPaymentTradeOrder>(false, FrameworkEnum.StatusCode.NoService);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PagePaymentTradeOrder> PageTrade(PagePaymentTradeParam paramObj)
        {
            return new ResultModel<PagePaymentTradeOrder>(false, FrameworkEnum.StatusCode.NoService);
        }
    }
}
