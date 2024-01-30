using Microsoft.Extensions.Logging;
using Sha.UserService.Dal.Common;
using Sha.UserService.Model.Entity;
using SqlSugar;

namespace Sha.UserService.Dal
{
    /// <summary>
    /// 账户
    /// </summary>
    public class AccountDal : UserServiceDal
    {
        /// <summary>
        /// 账户
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public AccountDal(ISqlSugarClient db, ILogger<UserServiceDal> logger) : base(db, logger) { }


        /// <summary>
        /// 创建充值交易
        /// </summary>
        /// <param name="recharge"></param>
        /// <returns></returns>
        public bool CreateTrade(t_RechargeTrade recharge) => db.Insertable<t_RechargeTrade>(recharge).ExecuteCommand() > 0;
    }
}
