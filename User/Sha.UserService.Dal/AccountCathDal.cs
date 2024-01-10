using Sha.UserService.Dal.Common;
using Sha.UserService.Model.Entity;
using SqlSugar;

namespace Sha.UserService.Dal
{
    /// <summary>
    /// 现金账户
    /// </summary>
    public class AccountCathDal : UserServiceDal
    {
        /// <summary>
        /// 现金账户
        /// </summary>
        /// <param name="db"></param>
        public AccountCathDal(ISqlSugarClient db) : base(db)
        {
        }

        /// <summary>
        /// 创建充值交易
        /// </summary>
        /// <param name="recharge"></param>
        /// <returns></returns>
        public bool CreateTrade(t_RechargeTrade recharge)
        {
            db.Insertable<t_RechargeTrade>(recharge).ExecuteCommand();
            return true;
        }
    }
}
