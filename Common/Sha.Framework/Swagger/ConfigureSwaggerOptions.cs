using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Sha.Framework.Common;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Sha.Framework.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="provider"></param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            var setting = AppSettingHelper.GetObject<ServiceSetting>(ServiceSetting.KEY);
            ArgumentNullException.ThrowIfNull(setting);

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo()
                {
                    Title = $"{setting.PrefixName} API",
                    Version = description.ApiVersion.ToString(),
                    Description = $"{setting.PrefixName} {description.ApiVersion} 版本"
                });
            }
        }
    }
}
