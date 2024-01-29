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
        /// <param name="id">ID</param>
        /// <returns></returns>
        public t_Employee GetById(int id) => db.Queryable<t_Employee>().First(P => P.ID == id);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">工号</param>
        /// <returns></returns>
        public t_Employee GetByNumber(string number) => db.Queryable<t_Employee>().First(P => P.Number == number);

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Create(t_Employee employee) => db.Insertable(employee).ExecuteCommand() > 0;
    }
}
