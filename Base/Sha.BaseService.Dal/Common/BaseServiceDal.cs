using Sha.Framework.Base;
using SqlSugar;

namespace Sha.BaseService.Dal.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseServiceDal : ShaServiceDal
    {
        public readonly ISqlSugarClient db;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public BaseServiceDal(ISqlSugarClient db)
        {
            this.db = db;
        }
    }
}
