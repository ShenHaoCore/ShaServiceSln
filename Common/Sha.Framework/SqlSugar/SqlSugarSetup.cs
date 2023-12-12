/*************************************************************************************
 * 
 * 文 件 名：SqlSugarSetup.cs
 * 描    述：SqlSugar安装服务
 * 
 * 版    本：V1.0
 * 创 建 者：Shenhao
 * 创建时间：2023/09/20
 * ======================================
 * 历史更新记录
 * 版本：V1.0  修改时间：2023/11/11  修改人：Shenhao    修改内容：新建文件
 * ======================================
 * 引入NuGet包：SqlSugarCore
 * 
*************************************************************************************/

using Sha.Framework.Common;
using SqlSugar;

namespace Sha.Framework.SqlSugar
{
    /// <summary>
    /// SqlSugar安装服务
    /// </summary>
    public static class SqlSugarSetup
    {
        /// <summary>
        /// SqlSugar注册
        /// </summary>
        /// <param name="services"></param>
        public static void AddSqlSugarSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(nameof(services));
            ArgumentNullException.ThrowIfNull(AppSettingHelper.config);
            string connString = AppSettingHelper.config.GetConnectionString("ShaService") ?? throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(connString)) { throw new ArgumentNullException(nameof(connString)); }

            List<ConnectionConfig> connections = new List<ConnectionConfig> { new ConnectionConfig() { ConnectionString = connString, DbType = DbType.SqlServer, IsAutoCloseConnection = true } };
            SqlSugarScope scope = new SqlSugarScope(connections, db => { db.Aop.OnLogExecuting = ConsoleSql; });
            services.AddSingleton<ISqlSugarClient>(scope);
        }

        /// <summary>
        /// 打印SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        public static void ConsoleSql(string sql, SugarParameter[] pars)
        {
#if DEBUG
            Console.WriteLine(sql);
            Console.WriteLine(string.Join(",", pars.Select(it => $"{it.ParameterName}:{it.Value}")));
#endif
        }
    }
}
