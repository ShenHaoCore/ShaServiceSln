using Microsoft.Extensions.Logging;
using Sha.Framework.Base;

namespace Sha.UserService.Bll.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class UserServiceBll : ShaServiceBll
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">日志</param>
        public UserServiceBll(ILogger<UserServiceBll> logger) : base(logger)
        {
        }
    }
}
