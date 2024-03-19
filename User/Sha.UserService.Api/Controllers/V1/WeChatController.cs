using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sha.Business.WeChat;
using Sha.Framework.Base;

namespace Sha.UserService.Api.Controllers.V1
{
    /// <summary>
    /// 微信
    /// </summary>
    [ApiVersion(1.0)]
    public class WeChatController : ShaBaseController
    {
        private readonly IWeChatMerchant client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="client"></param>
        public WeChatController(ILogger<WeChatController> logger, IMapper mapper, IWeChatMerchant client) : base(logger, mapper)
        {
            this.client = client;
        }

        /// <summary>
        /// 通知
        /// </summary>
        [HttpPost]
        public void Notify()
        {
            NotifyHeader header = WeChatHelper.GetNotifyHeader(this.Request);
            client.GetCert(header.SerialNo);
        }
    }
}
