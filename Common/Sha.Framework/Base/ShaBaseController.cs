using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Sha.Framework.Base
{
    /// <summary>
    /// SHA 基础 控制器
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ShaBaseController : ControllerBase
    {
        /// <summary>
        /// 日志
        /// </summary>
        public readonly ILogger<ShaBaseController> logger;

        /// <summary>
        /// 映射
        /// </summary>
        public readonly IMapper mapper;

        /// <summary>
        /// 控制器
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        public ShaBaseController(ILogger<ShaBaseController> logger, IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }
    }
}
