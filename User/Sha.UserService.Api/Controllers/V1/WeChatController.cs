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
        private readonly IWeChatClient client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">自动映射</param>
        /// <param name="client"></param>
        public WeChatController(ILogger<WeChatController> logger, IMapper mapper, IWeChatClient client) : base(logger, mapper)
        {
            this.client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public void Notify()
        {
            client.GetCertificates("724EB39A82961A2582A8BE95C2C8F2347CAA8BEA");
        }
    }
}
