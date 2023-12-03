using Microsoft.Extensions.Logging;
using Sha.Framework.Base;

namespace Sha.BaseService.Bll.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseServiceBll : ShaServiceBll
    {
        public readonly ILogger<BaseServiceBll> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public BaseServiceBll(ILogger<BaseServiceBll> logger)
        {
            this.logger = logger;
        }
    }
}
