using Sha.UserService.Dal.Common;
using Sha.UserService.Model.Entity;
using SqlSugar;

namespace Sha.UserService.Dal
{
    /// <summary>
    /// 员工
    /// </summary>
    public class EmployeDal : UserServiceDal
    {
        private readonly ISqlSugarClient db;

        /// <summary>
        /// 员工
        /// </summary>
        /// <param name="db"></param>
        public EmployeDal(ISqlSugarClient db)
        {
            this.db = db;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">工号</param>
        /// <returns></returns>
        public t_Employe GetByNumber(string number)
        {
            return db.Queryable<t_Employe>().First(P => P.Number == number);
        }
    }
}
