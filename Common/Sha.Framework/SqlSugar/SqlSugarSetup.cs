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
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(AppSettingHelper.config);
            string connectionString = AppSettingHelper.GetConnectionString("ShaService") ?? throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(connectionString)) { throw new ArgumentNullException(nameof(connectionString)); }

            List<ConnectionConfig> connections = new List<ConnectionConfig> { new ConnectionConfig() { ConnectionString = connectionString, DbType = DbType.SqlServer, IsAutoCloseConnection = true } };
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
            Console.WriteLine(sql); // 输出SQL, 查看执行SQL  性能无影响
            Console.WriteLine(string.Join(",", pars.Select(it => $"{it.ParameterName}:{it.Value}")));

            // Console.WriteLine(UtilMethods.GetNativeSql(sql, pars)); // 获取原生SQL推荐 5.1.4.63  性能OK
            Console.WriteLine(UtilMethods.GetSqlString(DbType.SqlServer, sql, pars)); // 获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
#endif
        }
    }
}
