﻿using SqlSugar;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 沙数据访问层
    /// </summary>
    public class ShaServiceDal : IShaServiceDal
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly ISqlSugarClient db;

        /// <summary>
        /// 
        /// </summary>
        public readonly ILogger<ShaServiceDal> logger;

        /// <summary>
        /// 沙数据访问层
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public ShaServiceDal(ISqlSugarClient db, ILogger<ShaServiceDal> logger)
        {
            this.db = db;
            this.logger = logger;
        }
    }
}
