using Sha.UserService.Dal.Common;
using Sha.UserService.Model.Entity;
using SqlSugar;

namespace Sha.UserService.Dal
{
    /// <summary>
    /// 身份证
    /// </summary>
    public class IdentityCardDal : UserServiceDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public IdentityCardDal(ISqlSugarClient db) : base(db)
        {
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">公民身份号码</param>
        /// <returns></returns>
        public t_IdentityCard GetByNumber(string number)
        {
            return db.Queryable<t_IdentityCard>().First(P => P.Number == number);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public bool Create(t_IdentityCard idcard)
        {
            db.Insertable<t_IdentityCard>(idcard).ExecuteCommand();
            return true;
        }
    }
}
