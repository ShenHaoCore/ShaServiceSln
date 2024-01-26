using Microsoft.Extensions.Logging;
using Sha.UserService.Dal.Common;
using Sha.UserService.Model.DTO;
using Sha.UserService.Model.Entity;
using SqlSugar;

namespace Sha.UserService.Dal
{
    /// <summary>
    /// 身份证
    /// </summary>
    public class IdcardDal : UserServiceDal
    {
        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public IdcardDal(ISqlSugarClient db, ILogger<IdcardDal> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">公民身份号码</param>
        /// <returns></returns>
        public t_IdentityCard GetByNumber(string number) => db.Queryable<t_IdentityCard>().First(P => P.Number == number);

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

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="qryParam"></param>
        /// <returns></returns>
        public List<t_IdentityCard> QueryPage(IdcardQueryPage qryParam)
        {
            int totalNumber = 0;
            List<t_IdentityCard> cards = db.Queryable<t_IdentityCard>()
                .WhereIF(!string.IsNullOrWhiteSpace(qryParam.Name), it => it.Name == qryParam.Name)
                .WhereIF(!string.IsNullOrWhiteSpace(qryParam.Number), it => it.Number == qryParam.Number)
                .WhereIF(qryParam.Sex.HasValue, it => it.Sex == qryParam.Sex)
                .WhereIF(qryParam.Nation.HasValue, it => it.Nation == qryParam.Nation)
                .WhereIF(qryParam.Birthday.HasValue, it => SqlFunc.DateIsSame(it.Birthday, qryParam.Birthday))
                .OrderByDescending(it => it.ID)
                .ToPageList(qryParam.PageIndex, qryParam.PageSize, ref totalNumber);
            qryParam.TotalNumber = totalNumber;
            return cards;
        }
    }
}
