using Sha.BaseService.Dal.Common;
using Sha.BaseService.Model.Entity;
using SqlSugar;

namespace Sha.BaseService.Dal
{
    /// <summary>
    /// 地址
    /// </summary>
    public class AddressDal : BaseServiceDal
    {
        private readonly ISqlSugarClient db;

        /// <summary>
        /// 地址
        /// </summary>
        /// <param name="db"></param>
        public AddressDal(ISqlSugarClient db)
        {
            this.db = db;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool Create(t_Address address)
        {
            db.Insertable<t_Address>(address).ExecuteCommand();
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool Update(t_Address address)
        {
            db.Updateable<t_Address>(address).UpdateColumns(it => new
            {
                it.Code,
                it.Number,
                it.NameCn,
                it.NameEn,
                it.ShortName,
                it.ParentKey,
                it.Type,
                it.Sort,
                it.IsDelete
            }).ExecuteCommand();
            return true;
        }
    }
}
