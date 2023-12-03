using Microsoft.Extensions.Logging;
using Sha.Framework.Base;

namespace Sha.UserService.Bll.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class UserServiceBll : ShaServiceBll
    {
        public readonly ILogger<UserServiceBll> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public UserServiceBll(ILogger<UserServiceBll> logger)
        {
            this.logger = logger;
        }
    }
}
