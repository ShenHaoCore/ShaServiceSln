using Sha.UserService.Dal.Common;
using SqlSugar;

namespace Sha.UserService.Dal
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountCathDal : UserServiceDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public AccountCathDal(ISqlSugarClient db) : base(db)
        {
        }
    }
}
