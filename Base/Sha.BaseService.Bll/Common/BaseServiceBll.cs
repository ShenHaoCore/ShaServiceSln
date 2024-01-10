using Microsoft.Extensions.Logging;
using Sha.Framework.Base;

namespace Sha.BaseService.Bll.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseServiceBll : ShaServiceBll
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">日志</param>
        public BaseServiceBll(ILogger<BaseServiceBll> logger) : base(logger)
        {
        }
    }
}
