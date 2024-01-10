using Microsoft.Extensions.Logging;
using Sha.Framework.Base;
using SqlSugar;

namespace Sha.BaseService.Dal.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseServiceDal : ShaServiceDal
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public BaseServiceDal(ISqlSugarClient db, ILogger<BaseServiceDal> logger) : base(db, logger)
        {
        }
    }
}
