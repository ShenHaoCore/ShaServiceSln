/*************************************************************************************
 * 
 * 文 件 名：CorsSetup.cs
 * 描    述：跨域安装服务
 * 
 * 1.支持多个域名端口，注意端口号后不要带/斜杆，比如：http://localhost:8000/，是错的
 * 2.注意：http://127.0.0.1:1818 和 http://localhost:1818 是不一样的
 * 
 * 版    本：V1.0
 * 创 建 者：Shenhao
 * 创建时间：2024/1/25
 * ===================================================================================
 * 历史更新记录
 * 版本：V1.0  修改时间：2024/1/25  修改人：Shenhao    修改内容：新建文件
 * ===================================================================================
 * 引入NuGet包：
 * 
*************************************************************************************/

namespace Sha.Framework.Cors
{
    /// <summary>
    /// 跨域启动服务
    /// </summary>
    public static class CorsSetup
    {
        /// <summary>
        /// 添加跨域
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            bool isEnable = false; // 是否启用
            if (!isEnable) { return; }

            string[] origins = ["http://localhost:5173"];
            services.AddCors(options =>
            {
                options.AddPolicy("ShaSite", builder =>
                {
                    builder.WithOrigins(origins); // 允许指定站点
                    builder.SetIsOriginAllowed((host) => true); // 允许所有站点
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowCredentials();
                });
            });
        }
    }
}
