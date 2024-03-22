using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using Sha.Business.WeChat;
using Sha.Common.Extension;
using Sha.Common.Helper;
using Sha.Framework.Base;
using Sha.Framework.Common;
using System.Security.Cryptography.X509Certificates;

namespace Sha.UserService.Api.Controllers.V1
{
    /// <summary>
    /// 微信
    /// </summary>
    [ApiVersion(1.0)]
    public class WeChatController : ShaBaseController
    {
        private readonly IWeChatMerchant client;
        private readonly WeChatSetting setting;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="client"></param>
        public WeChatController(ILogger<WeChatController> logger, IMapper mapper, IWeChatMerchant client) : base(logger, mapper)
        {
            this.client = client;
            this.setting = AppSettingHelper.GetObject<WeChatSetting>(WeChatSetting.KEY) ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// 通知
        /// </summary>
        [HttpPost]
        public NotifyResponse Notify([FromBody] NotifyRequest request)
        {
            NotifyResponse response = new NotifyResponse();
            logger.LogDebug($"微信通知请求 BODY：{request.ToJson()}");
            if (request == null) { logger.LogDebug("微信通知参数为空"); response.Code = "FAIL"; response.Message = "失败"; return response; }
            if (request.EventType != "TRANSACTION.SUCCESS") { logger.LogDebug("微信通知充值失败"); response.Code = "FAIL"; response.Message = "失败"; return response; }
            NotifyHeader header = WeChatHelper.GetNotifyHeader(this.Request);
            logger.LogDebug($"微信通知请求 HEADER：{header.ToJson()}");
            string body = JsonConvert.SerializeObject(request);
            string message = $"{header.Timestamp}\n{header.Nonce}\n{body}\n";
            var wechatcert = client.GetPlatformCert(header.SerialNo); // 获取微信证书
            if (wechatcert == null) { logger.LogDebug("微信通知证书获取失败"); response.Code = "FAIL"; response.Message = "失败"; return response; }
            var rsa = wechatcert.Cert.GetRSAPublicKey();
            if (rsa == null) { response.Code = "FAIL"; response.Message = "失败"; return response; }
            bool flag = WeChatHelper.VerifyData(rsa, message, header.Signature); // 验签
            logger.LogDebug($"微信通知验签{(flag ? "成功" : "失败")}");
            if (!flag) { response.Code = "FAIL"; response.Message = "失败"; return response; }
            string plaintext = AesHelper.GcmDecrypt(setting.APIv3Key, request.Resource.AssociatedData, request.Resource.Nonce, request.Resource.Ciphertext);
            var resource = plaintext.ToObject<TransactionsNotify>();
            if (resource == null) { logger.LogDebug("微信通知资料获取失败"); response.Code = "FAIL"; response.Message = "失败"; return response; }
            response.Code = "SUCCESS";
            response.Message = "成功";
            return response;
        }
    }
}
