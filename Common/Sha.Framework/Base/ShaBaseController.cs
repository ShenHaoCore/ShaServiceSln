using Microsoft.AspNetCore.Mvc;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ShaBaseController : ControllerBase
    {
        public readonly ILogger<ShaBaseController> logger;

        /// <summary>
        /// SHA 基础 控制器
        /// </summary>
        public ShaBaseController(ILogger<ShaBaseController> logger)
        {
            this.logger = logger;
        }
    }
}
