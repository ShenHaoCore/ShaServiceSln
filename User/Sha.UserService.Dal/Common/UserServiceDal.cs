using Sha.Framework.Base;
using SqlSugar;

namespace Sha.UserService.Dal.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class UserServiceDal : ShaServiceDal
    {
        public readonly ISqlSugarClient db;

        /// <summary>
        /// 
        /// </summary>
        public UserServiceDal(ISqlSugarClient db)
        {
            this.db = db;
        }
    }
}
