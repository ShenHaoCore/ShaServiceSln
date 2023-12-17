using System.Net;

namespace Sha.Framework.Consul
{
    /// <summary>
    /// 心跳检查
    /// </summary>
    public static class HealthCheckMiddleware
    {
        /// <summary>
        /// 设置心跳检查
        /// </summary>
        /// <param name="app"></param>
        /// <param name="checkPath">默认是/healthcheck</param>
        /// <returns></returns>
        public static void UseHealthCheckMiddle(this IApplicationBuilder app, string checkPath = "/healthcheck")
        {
            app.Map(checkPath, applicationBuilder => applicationBuilder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync("OK");
            }));
        }
    }
}
