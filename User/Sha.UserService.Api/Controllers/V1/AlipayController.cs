using Aop.Api.Util;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Sha.Business.Alipay;
using Sha.Framework.Base;
using Sha.Framework.Common;

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
        public ActionResult Notify()
        {
            var setting = AppSettingHelper.GetObject<AlipaySetting>(AlipaySetting.KEY);
            ArgumentNullException.ThrowIfNull(setting);
            string nResponse = "failure";
            IDictionary<string, string> sArray = new Dictionary<string, string>();
            foreach (string key in Request.Form.Keys) { if (Request.Form.TryGetValue(key, out StringValues values)) { sArray.Add(key, values.First() ?? ""); } }
            bool flag = AlipaySignature.RSACheckV1(sArray, setting.AlipayPublicKey, "UTF-8", "RSA2", false);
            return Content(nResponse);
        }
    }
}
