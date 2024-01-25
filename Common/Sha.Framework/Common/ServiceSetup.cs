using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sha.Framework.Filter;

namespace Sha.Framework.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="prefixName">前缀</param>
        public static void AddControllerSetup(this IServiceCollection services, string prefixName)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddControllers(option =>
            {
                option.Filters.Add<GlobalExceptionFilter>();
                option.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(prefixName)));
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // 序列化时KEY为驼峰样式
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // 忽略循环引用
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; // 时间格式化
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            });
        }

        /// <summary>
        /// 接口版本
        /// </summary>
        /// <param name="services"></param>
        public static void AddApiVersionSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("X-API-VERSION"), new MediaTypeApiVersionReader("VER"));
            }).AddMvc().AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
