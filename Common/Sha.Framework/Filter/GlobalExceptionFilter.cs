using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.Framework.Filter
{
    /// <summary>
    /// 全局异常
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment environment;
        private readonly ILogger<GlobalExceptionFilter> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="logger">日志</param>
        public GlobalExceptionFilter(IWebHostEnvironment environment, ILogger<GlobalExceptionFilter> logger)
        {
            this.environment = environment;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled) // 如果异常没有处理
            {
                BaseResponse response = new BaseResponse(false, FrameworkEnum.StatusCode.ServerError);
                response.Exception = new BaseResponseException() { StackTrace = context.Exception.StackTrace ?? "", Source = context.Exception.Source ?? "", Message = context.Exception.Message ?? "" };
                if (environment.IsDevelopment()) { }
                logger.LogError(context.Exception, $"系统错误：{context.Exception.Message}");
                context.Result = new JsonResult(response);
                context.ExceptionHandled = true; // 异常已处理
            }
        }
    }
}
