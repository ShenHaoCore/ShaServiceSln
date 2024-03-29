﻿using Microsoft.Extensions.Logging;
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
        /// <summary>
        /// 地址
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public AddressDal(ISqlSugarClient db, ILogger<AddressDal> logger) : base(db, logger)
        {
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public t_Address GetByKey(Guid key) => db.Queryable<t_Address>().First(it => it.Key == key);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public t_Address GetByCode(string code) => db.Queryable<t_Address>().First(it => it.Code == code);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<t_Address> GetByParentKey(Guid key) => db.Queryable<t_Address>().Where(it => it.ParentKey == key).OrderBy(it => it.Sort).ToList();

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
            db.Updateable<t_Address>(address).UpdateColumns(it => new { it.Code, it.Number, it.NameCn, it.NameEn, it.ShortName, it.ParentKey, it.Type, it.Sort, it.IsDelete }).ExecuteCommand();
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(Guid key)
        {
            db.Deleteable<t_Address>().Where(it => it.Key == key).ExecuteCommand();
            return true;
        }
    }
}
