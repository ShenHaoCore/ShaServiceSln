using Microsoft.Extensions.Logging;
using Sha.Framework.Base;
using SqlSugar;

namespace Sha.UserService.Dal.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class UserServiceDal : ShaServiceDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public UserServiceDal(ISqlSugarClient db, ILogger<UserServiceDal> logger) : base(db, logger)
        {
        }
    }
}
