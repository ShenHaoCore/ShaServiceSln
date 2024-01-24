using Serilog;
using Serilog.Events;
using Sha.Framework.Common;

namespace Sha.Framework.Serilog
{
    /// <summary>
    /// Serilog安装服务
    /// </summary>
    public static class SerilogSetup
    {
        private static readonly string LogTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level:u3}] 日志信息：{Message:lj}{NewLine}";
        private static readonly string ErrorTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level:u3}] 日志信息：{Message:lj}{NewLine}{Exception}{NewLine}";

        /// <summary>
        /// Serilog注册
        /// </summary>
        /// <param name="host"></param>
        public static IHostBuilder AddSerilogSetup(this IHostBuilder host)
        {
            ArgumentNullException.ThrowIfNull(nameof(host));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteToFileAsync()
                .CreateBootstrapLogger();

            host.UseSerilog();
            return host;
        }

        /// <summary>
        /// 异步写入文件
        /// </summary>
        /// <param name="logConfig"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToFileAsync(this LoggerConfiguration logConfig)
        {
            logConfig = logConfig.WriteTo.Async(P => P.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs/LOG_.log"), rollingInterval: RollingInterval.Day, outputTemplate: LogTemplate));
            logConfig = logConfig.WriteTo.Logger(G => G.Filter.ByIncludingOnly(P => P.Level == LogEventLevel.Error).WriteTo.Async(P => P.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs/ERR_.log"), rollingInterval: RollingInterval.Day, outputTemplate: ErrorTemplate)));
            return logConfig;
        }
    }
}
