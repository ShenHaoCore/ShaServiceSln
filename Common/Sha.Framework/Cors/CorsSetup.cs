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

using Sha.Framework.Common;

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
            bool enable = false;
            if (!enable) { return; }

            ArgumentNullException.ThrowIfNull(services);
            var setting = AppSettingHelper.GetObject<CorsSetting>(CorsSetting.KEY);
            ArgumentNullException.ThrowIfNull(setting);
            if (!setting.Enable) { return; }

            string[] origins = setting.Origins is null ? [] : [.. setting.Origins];
            services.AddCors(options =>
            {
                options.AddPolicy(CorsConst.ALLOWANY, builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((host) => true));
                options.AddPolicy(CorsConst.ORIGINS, builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins(origins));
            });
        }
    }
}
