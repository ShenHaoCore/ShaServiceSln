using AutoMapper;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class ShaServiceBll : IShaServiceBll
    {
        /// <summary>
        /// 日志
        /// </summary>
        public readonly ILogger<ShaServiceBll> logger;

        /// <summary>
        /// 自动映射
        /// </summary>
        public readonly IMapper mapper;

        /// <summary>
        /// 业务逻辑层
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">自动映射</param>
        public ShaServiceBll(ILogger<ShaServiceBll> logger, IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }
    }
}
