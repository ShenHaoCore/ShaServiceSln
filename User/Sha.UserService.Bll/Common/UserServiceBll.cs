using AutoMapper;
using Microsoft.Extensions.Logging;
using Sha.Framework.Base;

namespace Sha.UserService.Bll.Common
{
    /// <summary>
    /// 用户 业务逻辑层
    /// </summary>
    public class UserServiceBll : ShaServiceBll
    {
        /// <summary>
        /// 用户 业务逻辑层
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        public UserServiceBll(ILogger<UserServiceBll> logger, IMapper mapper) : base(logger, mapper)
        {
        }
    }
}
