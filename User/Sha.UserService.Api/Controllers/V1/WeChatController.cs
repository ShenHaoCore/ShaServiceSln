using Asp.Versioning;
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
        private readonly IWeChatClient client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="client"></param>
        public WeChatController(ILogger<WeChatController> logger, IWeChatClient client) : base(logger)
        {
            this.client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public void Notify()
        {
            client.GetCertificates();
        }
    }
}
