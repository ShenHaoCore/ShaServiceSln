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

        /// <summary>
        /// 支付宝客户端
        /// </summary>
        /// <param name="logger"></param>
        public AlipayClient(ILogger<AlipayClient> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// 创建APP订单
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<TradeAppOrder> TradeAppPay(TradeAppParam paramObj)
        {
            try
            {
                logger.LogDebug($"支付宝创建APP订单，参数【{JsonConvert.SerializeObject(paramObj)}】");
                var config = AppSettings.GetObject<AlipayConfig>(AlipayConfig.KEY);
                if (config == null) { return new ResultModel<TradeAppOrder>(false, FrameworkEnum.StatusCode.NullConfig); }
                IAopClient client = new DefaultAopClient(config.ServerUrl, config.AppID, config.MerchantPrivateKey, "json", "1.0", "RSA2", config.AlipayPublicKey, "UTF-8", false);
                AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
                AlipayTradeAppPayModel bizmodel = new AlipayTradeAppPayModel()
                {
                    Body = paramObj.Body,
                    Subject = paramObj.Subject,
                    TotalAmount = paramObj.TotalAmount,
                    ProductCode = paramObj.ProductCode,
                    OutTradeNo = paramObj.OutTradeNo,
                    TimeoutExpress = paramObj.TimeoutExpress
                };
                request.SetBizModel(bizmodel);
                request.SetNotifyUrl(config.NotifyUrl);
                AlipayTradeAppPayResponse response = client.SdkExecute(request);
                logger.LogDebug($"支付宝创建APP订单，响应【{JsonConvert.SerializeObject(response)}】");
                if (response == null) { return new ResultModel<TradeAppOrder>(false, FrameworkEnum.StatusCode.ResponseNull); }
                return new ResultModel<TradeAppOrder>(true, FrameworkEnum.StatusCode.Success, new TradeAppOrder(response));
            }
            catch (Exception ex)
            {
                logger.LogError("支付宝创建APP订单异常", ex);
                return new ResultModel<TradeAppOrder>(false, FrameworkEnum.StatusCode.ServerError);
            }
        }

        /// <summary>
        /// 创建PAGE订单
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<TradePageOrder> TradePagePay(TradePageParam paramObj)
        {
            try
            {
                logger.LogDebug($"支付宝创建PAGE订单，参数【{JsonConvert.SerializeObject(paramObj)}】");
                var config = AppSettings.GetObject<AlipayConfig>(AlipayConfig.KEY);
                if (config == null) { return new ResultModel<TradePageOrder>(false, FrameworkEnum.StatusCode.NullConfig); }
                IAopClient client = new DefaultAopClient(config.ServerUrl, config.AppID, config.MerchantPrivateKey, "json", "1.0", "RSA2", config.AlipayPublicKey, "UTF-8", false);
                AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
                AlipayTradePagePayModel bizModel = new AlipayTradePagePayModel()
                {
                    Body = paramObj.Body,
                    Subject = paramObj.Subject,
                    TotalAmount = paramObj.TotalAmount,
                    ProductCode = paramObj.ProductCode,
                    OutTradeNo = paramObj.OutTradeNo,
                    TimeoutExpress = paramObj.TimeoutExpress
                };
                request.SetBizModel(bizModel);
                request.SetNotifyUrl(config.NotifyUrl);
                request.SetReturnUrl(config.ReturnUrl);
                string method = BusinessEnum.RequestMethod.POST.ToString(); // POST方式请求，生成FORM表单
                if (paramObj.RequestMethod.Equals(BusinessEnum.RequestMethod.GET.ToString(), StringComparison.OrdinalIgnoreCase)) { method = BusinessEnum.RequestMethod.GET.ToString(); } // GET方式请求，即生成URL链接;
                AlipayTradePagePayResponse response = client.pageExecute(request, "", method);
                logger.LogDebug($"支付宝创建PAGE订单，响应【{JsonConvert.SerializeObject(response)}】");
                if (response == null) { return new ResultModel<TradePageOrder>(false, FrameworkEnum.StatusCode.ResponseNull); }
                return new ResultModel<TradePageOrder>(true, FrameworkEnum.StatusCode.Success, new TradePageOrder(response));
            }
            catch (Exception ex)
            {
                logger.LogError("支付宝创建PAGE订单，异常", ex);
                return new ResultModel<TradePageOrder>(false, FrameworkEnum.StatusCode.ServerError);
            }
        }
    }
}
