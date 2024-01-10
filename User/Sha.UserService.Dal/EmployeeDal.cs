using Microsoft.Extensions.Logging;
using Sha.UserService.Dal.Common;
using Sha.UserService.Model.Entity;
using SqlSugar;

namespace Sha.UserService.Dal
{
    /// <summary>
    /// 员工
    /// </summary>
    public class EmployeeDal : UserServiceDal
    {
        /// <summary>
        /// 员工
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public EmployeeDal(ISqlSugarClient db, ILogger<EmployeeDal> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">工号</param>
        /// <returns></returns>
        public t_Employee GetByNumber(string number) => db.Queryable<t_Employee>().First(P => P.Number == number);
    }
}
