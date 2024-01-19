using Org.BouncyCastle.Asn1.Ocsp;
using Serilog;
using Serilog.Events;
using Sha.Framework.Http;

namespace Sha.Framework.Serilog
{
    /// <summary>
    /// Serilog中间件
    /// </summary>
    public static class SerilogMiddleware
    {
        private static readonly string CustomizeTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms"; // 自定义消息模板（Customize The Message Template）

        /// <summary>
        /// 使用Serilog
        /// </summary>
        /// <param name="app"></param>
        public static void UseSerilogMiddle(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.MessageTemplate = CustomizeTemplate;
                options.GetLevel = GetLogLevel;
                options.EnrichDiagnosticContext = EnrichFromRequest;
            });
        }

        /// <summary>
        /// 获取日志等级
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="elapsed"></param>
        /// <param name="ex"></param>
        public static LogEventLevel GetLogLevel(HttpContext httpContext, double elapsed, Exception? ex)
        {
            if (ex is not null) { return LogEventLevel.Error; }
            return LogEventLevel.Debug;
        }

        /// <summary>
        /// 从Request中增加附属属性
        /// </summary>
        /// <param name="diagnosticContext"></param>
        /// <param name="httpContext"></param>
        public static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
            var endpoint = httpContext.GetEndpoint();

            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
            diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
            diagnosticContext.Set("Protocol", httpContext.Request.Protocol);
            diagnosticContext.Set("RequestIp", httpContext.GetRequestIp());
            diagnosticContext.Set("QueryString", httpContext.Request.QueryString.HasValue ? httpContext.Request.QueryString.Value : string.Empty);
            diagnosticContext.Set("Body", httpContext.Request.ContentLength > 0 ? httpContext.Request.GetRequestBodyAsync() : string.Empty);
            diagnosticContext.Set("ContentType", httpContext.Response.ContentType);
            diagnosticContext.Set("EndpointName", endpoint != null ? endpoint.DisplayName : string.Empty);
        }
    }
}
