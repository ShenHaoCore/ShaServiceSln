using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Microsoft.Extensions.Logging;
using Sha.Business.Enum;
using Sha.Common.Extension;
using Sha.Framework.Common;

namespace Sha.Business.Alipay
{
    /// <summary>
    /// 支付宝客户端
    /// </summary>
    public class AlipayClient : IAlipayClient
    {
        private readonly ILogger<AlipayClient> logger;
        private readonly AlipaySetting setting;

        /// <summary>
        /// 支付宝客户端
        /// </summary>
        /// <param name="logger">日志</param>
        public AlipayClient(ILogger<AlipayClient> logger)
        {
            this.logger = logger;
            this.setting = AppSettingHelper.GetObject<AlipaySetting>(AlipaySetting.KEY) ?? throw new ArgumentNullException();
        }

        public readonly string Version = "1.0";
        public readonly string Format = "JSON";
        public readonly string SignType = "RSA2";
        public readonly string Charset = "UTF-8";

        /// <summary>
        /// APP支付
        /// </summary>
        /// <param name="bizmodel"></param>
        /// <returns></returns>
        public AlipayTradeAppPayResponse? TradeAppPay(AlipayTradeAppPayModel bizmodel)
        {
            try
            {
                logger.LogDebug($"APP支付，参数【{bizmodel.ToJson()}】");
                IAopClient client = new DefaultAopClient(setting.ServerUrl, setting.AppID, setting.MerchantPrivateKey, Format, Version, SignType, setting.AlipayPublicKey, Charset, false);
                AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
                request.SetBizModel(bizmodel);
                request.SetNotifyUrl(setting.NotifyUrl);
                AlipayTradeAppPayResponse response = client.SdkExecute(request);
                logger.LogDebug($"APP支付，响应【{response.ToJson()}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "APP支付异常");
                return null;
            }
        }

        /// <summary>
        /// 电脑网站支付
        /// </summary>
        /// <param name="bizModel"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public AlipayTradePagePayResponse? TradePagePay(AlipayTradePagePayModel bizModel, BusinessEnum.RequestMethod method)
        {
            try
            {
                logger.LogDebug($"电脑网站支付，参数【{bizModel.ToJson()}】");
                IAopClient client = new DefaultAopClient(setting.ServerUrl, setting.AppID, setting.MerchantPrivateKey, Format, Version, SignType, setting.AlipayPublicKey, Charset, false);
                AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
                request.SetBizModel(bizModel);
                request.SetNotifyUrl(setting.NotifyUrl);
                request.SetReturnUrl(setting.ReturnUrl);
                AlipayTradePagePayResponse response = client.pageExecute(request, "", method.ToString());
                logger.LogDebug($"电脑网站支付，响应【{response.ToJson()}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "电脑网站支付异常");
                return null;
            }
        }

        /// <summary>
        /// 手机网站支付
        /// </summary>
        /// <param name="bizModel"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public AlipayTradeWapPayResponse? TradeWapPay(AlipayTradeWapPayModel bizModel, BusinessEnum.RequestMethod method)
        {
            try
            {
                logger.LogDebug($"手机网站支付，参数【{bizModel.ToJson()}】");
                IAopClient client = new DefaultAopClient(setting.ServerUrl, setting.AppID, setting.MerchantPrivateKey, Format, Version, SignType, setting.AlipayPublicKey, Charset, false);
                AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
                request.SetBizModel(bizModel);
                request.SetNotifyUrl(setting.NotifyUrl);
                request.SetReturnUrl(setting.ReturnUrl);
                AlipayTradeWapPayResponse response = client.pageExecute(request, "", method.ToString());
                logger.LogDebug($"手机网站支付，响应【{response.ToJson()}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "手机网站支付异常");
                return null;
            }
        }

        /// <summary>
        /// 付款码支付
        /// </summary>
        /// <param name="bizmodel"></param>
        /// <returns></returns>
        public AlipayTradePayResponse? TradePay(AlipayTradePayModel bizmodel)
        {
            try
            {
                logger.LogDebug($"付款码支付，参数【{bizmodel.ToJson()}】");
                IAopClient client = new DefaultAopClient(setting.ServerUrl, setting.AppID, setting.MerchantPrivateKey, Format, Version, SignType, setting.AlipayPublicKey, Charset, false);
                AlipayTradePayRequest request = new AlipayTradePayRequest();
                request.SetBizModel(bizmodel);
                request.SetNotifyUrl(setting.NotifyUrl);
                AlipayTradePayResponse response = client.Execute(request);
                logger.LogDebug($"付款码支付，响应【{response.ToJson()}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "付款码支付异常");
                return null;
            }
        }

        /// <summary>
        /// 扫码支付
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public AlipayTradePrecreateResponse? TradePrecreate(AlipayTradePrecreateModel bizmodel)
        {
            try
            {
                logger.LogDebug($"扫码支付，参数【{bizmodel.ToJson()}】");
                IAopClient client = new DefaultAopClient(setting.ServerUrl, setting.AppID, setting.MerchantPrivateKey, Format, Version, SignType, setting.AlipayPublicKey, Charset, false);
                AlipayTradePrecreateRequest request = new AlipayTradePrecreateRequest();
                request.SetBizModel(bizmodel);
                request.SetNotifyUrl(setting.NotifyUrl);
                AlipayTradePrecreateResponse response = client.Execute(request);
                logger.LogDebug($"扫码支付，响应【{response.ToJson()}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "扫码支付异常");
                return null;
            }
        }
    }
}
