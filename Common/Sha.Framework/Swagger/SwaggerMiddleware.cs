using Swashbuckle.AspNetCore.SwaggerUI;

namespace Sha.Framework.Swagger
{
    /// <summary>
    /// Swagger中间件
    /// </summary>
    public static class SwaggerMiddleware
    {
        /// <summary>
        /// 使用Swagger
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerMiddle(this WebApplication app)
        {
            if (app == null) { throw new ArgumentNullException(nameof(app)); }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                app.DescribeApiVersions().ToList().ForEach(description => { options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant()); });
                options.DocExpansion(DocExpansion.None); // 设置为None可折叠所有方法
                options.DefaultModelsExpandDepth(0); // 设置为-1 可不显示Models
            });
        }
    }
}
