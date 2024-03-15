using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sha.Business.Alipay;
using Sha.Framework.Base;

namespace Sha.UserService.Api.Controllers.V1
{
    /// <summary>
    /// 支付宝
    /// </summary>
    [ApiVersion(1.0)]
    public class AlipayController : ShaBaseController
    {
        private readonly IAlipayMerchant client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="client"></param>
        public AlipayController(ILogger<AlipayController> logger, IMapper mapper, IAlipayMerchant client) : base(logger, mapper)
        {
            this.client = client;
        }

        /// <summary>
        /// 通知
        /// </summary>
        [HttpPost]
        public void Notify()
        {
        }
    }
}
