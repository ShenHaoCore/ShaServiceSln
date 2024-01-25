using Asp.Versioning.ApiExplorer;
using Autofac.Core;
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
            var config = AppSettingHelper.GetObject<ServiceConfig>(ServiceConfig.KEY);
            ArgumentNullException.ThrowIfNull(config);

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo()
                {
                    Title = $"{config.PrefixName} API",
                    Version = description.ApiVersion.ToString(),
                    Description = $"{config.PrefixName} {description.ApiVersion} 版本"
                });
            }
        }
    }
}
