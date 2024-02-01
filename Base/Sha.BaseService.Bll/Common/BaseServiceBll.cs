using AutoMapper;
using Microsoft.Extensions.Logging;
using Sha.Framework.Base;

namespace Sha.BaseService.Bll.Common
{
    /// <summary>
    /// 基础 业务逻辑层
    /// </summary>
    public class BaseServiceBll : ShaServiceBll
    {
        /// <summary>
        /// 基础 业务逻辑层
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        public BaseServiceBll(ILogger<BaseServiceBll> logger, IMapper mapper) : base(logger, mapper)
        {
        }
    }
}
