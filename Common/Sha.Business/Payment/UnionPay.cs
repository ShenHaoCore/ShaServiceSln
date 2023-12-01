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
        public ResultModel<AppPaymentTradeModel> AppTrade(AppPaymentTradeParam paramObj)
        {
            return new ResultModel<AppPaymentTradeModel>(false, FrameworkEnum.StatusCode.NoService);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<PagePaymentTradeModel> PageTrade(PagePaymentTradeParam paramObj)
        {
            return new ResultModel<PagePaymentTradeModel>(false, FrameworkEnum.StatusCode.NoService);
        }
    }
}
