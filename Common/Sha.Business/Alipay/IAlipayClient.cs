using Aop.Api.Domain;
using Aop.Api.Response;
using Sha.Business.Enum;
using Sha.Framework.Base;

namespace Sha.Business.Alipay
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAlipayClient
    {
        /// <summary>
        /// APP支付
        /// </summary>
        /// <param name="bizmodel"></param>
        /// <returns></returns>
        AlipayTradeAppPayResponse? TradeAppPay(AlipayTradeAppPayModel bizmodel);

        /// <summary>
        /// 电脑网站支付
        /// </summary>
        /// <param name="bizModel"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        AlipayTradePagePayResponse? TradePagePay(AlipayTradePagePayModel bizModel, BusinessEnum.RequestMethod method);

        /// <summary>
        /// 手机网站支付
        /// </summary>
        /// <param name="bizModel"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        AlipayTradeWapPayResponse? TradeWapPay(AlipayTradeWapPayModel bizModel, BusinessEnum.RequestMethod method);

        /// <summary>
        /// 付款码支付
        /// </summary>
        /// <param name="bizmodel"></param>
        /// <returns></returns>
        AlipayTradePayResponse? TradePay(AlipayTradePayModel bizmodel);

        /// <summary>
        /// 扫码支付
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        AlipayTradePrecreateResponse? TradePrecreate(AlipayTradePrecreateModel bizmodel);
    }
}
