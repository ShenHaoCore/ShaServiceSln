using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Sha.Framework.Version;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Sha.Framework.Swagger
{
    /// <summary>
    /// Swagger启动服务
    /// </summary>
    public static class SwaggerSetup
    {
        /// <summary>
        /// Swagger注册
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlFileNames"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddSwaggerSetup(this IServiceCollection services, List<string> xmlFileNames)
        {
            if (services == null) { throw new ArgumentNullException(nameof(services)); }
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                xmlFileNames.ForEach(name => { if (File.Exists(Path.Combine(AppContext.BaseDirectory, name))) { options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, name), true); } });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } }, new List<string>() } });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { Description = "JWT授权 Bearer {Token}（注意两者之间是一个空格）", Name = "Authorization", In = ParameterLocation.Header, Type = SecuritySchemeType.ApiKey });
            });
        }
    }
}
