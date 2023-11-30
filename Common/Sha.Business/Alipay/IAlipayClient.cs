using Sha.Framework.Base;

namespace Sha.Business.Alipay
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAlipayClient
    {
        /// <summary>
        /// 创建APP订单
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        ResultModel<TradeAppOrder> TradeAppPay(TradeAppParam paramObj);

        /// <summary>
        /// 创建PAGE订单
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        ResultModel<TradePageOrder> TradePagePay(TradePageParam paramObj);
    }
}
