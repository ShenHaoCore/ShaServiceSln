using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sha.Business.Enum;
using Sha.Framework.Base;
using Sha.Framework.Common;
using Sha.Framework.Enum;

namespace Sha.Business.Alipay
{
    /// <summary>
    /// 支付宝客户端
    /// </summary>
    public class AlipayClient : IAlipayClient
    {
        private readonly ILogger<AlipayClient> logger;
        private readonly AlipayConfig config;

        /// <summary>
        /// 支付宝客户端
        /// </summary>
        /// <param name="logger">日志</param>
        public AlipayClient(ILogger<AlipayClient> logger)
        {
            this.logger = logger;
            var alipayconfig = AppSettings.GetObject<AlipayConfig>(AlipayConfig.KEY);
            if (alipayconfig == null) { throw new ArgumentNullException(nameof(alipayconfig)); }
            this.config = alipayconfig;
        }

        public readonly string Version  = "1.0";
        public readonly string Format  = "JSON";
        public readonly string SignType = "RSA2";
        public readonly string Charset  = "UTF-8";

        /// <summary>
        /// APP支付
        /// </summary>
        /// <param name="bizmodel"></param>
        /// <returns></returns>
        public AlipayTradeAppPayResponse? TradeAppPay(AlipayTradeAppPayModel bizmodel)
        {
            try
            {
                logger.LogDebug($"APP支付，参数【{JsonConvert.SerializeObject(bizmodel)}】");
                IAopClient client = new DefaultAopClient(config.ServerUrl, config.AppID, config.MerchantPrivateKey, Format, Version, SignType, config.AlipayPublicKey, Charset, false);
                AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
                request.SetBizModel(bizmodel);
                request.SetNotifyUrl(config.NotifyUrl);
                AlipayTradeAppPayResponse response = client.SdkExecute(request);
                logger.LogDebug($"APP支付，响应【{JsonConvert.SerializeObject(response)}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError("APP支付异常", ex);
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
                logger.LogDebug($"电脑网站支付，参数【{JsonConvert.SerializeObject(bizModel)}】");
                IAopClient client = new DefaultAopClient(config.ServerUrl, config.AppID, config.MerchantPrivateKey, Format, Version, SignType, config.AlipayPublicKey, Charset, false);
                AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
                request.SetBizModel(bizModel);
                request.SetNotifyUrl(config.NotifyUrl);
                request.SetReturnUrl(config.ReturnUrl);
                AlipayTradePagePayResponse response = client.pageExecute(request, "", method.ToString());
                logger.LogDebug($"电脑网站支付，响应【{JsonConvert.SerializeObject(response)}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError("电脑网站支付异常", ex);
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
                logger.LogDebug($"手机网站支付，参数【{JsonConvert.SerializeObject(bizModel)}】");
                IAopClient client = new DefaultAopClient(config.ServerUrl, config.AppID, config.MerchantPrivateKey, Format, Version, SignType, config.AlipayPublicKey, Charset, false);
                AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
                request.SetBizModel(bizModel);
                request.SetNotifyUrl(config.NotifyUrl);
                request.SetReturnUrl(config.ReturnUrl);
                AlipayTradeWapPayResponse response = client.pageExecute(request, "", method.ToString());
                logger.LogDebug($"手机网站支付，响应【{JsonConvert.SerializeObject(response)}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError("手机网站支付异常", ex);
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
                logger.LogDebug($"付款码支付，参数【{JsonConvert.SerializeObject(bizmodel)}】");
                IAopClient client = new DefaultAopClient(config.ServerUrl, config.AppID, config.MerchantPrivateKey, Format, Version, SignType, config.AlipayPublicKey, Charset, false);
                AlipayTradePayRequest request = new AlipayTradePayRequest();
                request.SetBizModel(bizmodel);
                request.SetNotifyUrl(config.NotifyUrl);
                AlipayTradePayResponse response = client.Execute(request);
                logger.LogDebug($"付款码支付，响应【{JsonConvert.SerializeObject(response)}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError("付款码支付异常", ex);
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
                logger.LogDebug($"扫码支付，参数【{JsonConvert.SerializeObject(bizmodel)}】");
                IAopClient client = new DefaultAopClient(config.ServerUrl, config.AppID, config.MerchantPrivateKey, Format, Version, SignType, config.AlipayPublicKey, Charset, false);
                AlipayTradePrecreateRequest request = new AlipayTradePrecreateRequest();
                request.SetBizModel(bizmodel);
                request.SetNotifyUrl(config.NotifyUrl);
                AlipayTradePrecreateResponse response = client.Execute(request);
                logger.LogDebug($"扫码支付，响应【{JsonConvert.SerializeObject(response)}】");
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError("扫码支付异常", ex);
                return null;
            }
        }
    }
}
