using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Sha.Framework.Enum;
using Sha.Framework.Redis;
using System.Security.Claims;

namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 员工权限要求
    /// </summary>
    public class EmployeeRequirement : IAuthorizationRequirement
    {
    }

    /// <summary>
    /// 员工权限要求处理程序
    /// </summary>
    public class EmployeeHandler : AuthorizationHandler<EmployeeRequirement>
    {
        private readonly IRedisManage redis;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redis"></param>
        public EmployeeHandler(IRedisManage redis)
        {
            this.redis = redis;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmployeeRequirement requirement)
        {
            var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role);
            if (context.Resource is DefaultHttpContext)
            {
                var httpContext = context.Resource as DefaultHttpContext;
                if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }
                if (httpContext.Request == null) { throw new ArgumentNullException(nameof(httpContext.Request)); }
                if (!httpContext.Request.Headers.TryGetValue(HeaderNames.Authorization, out StringValues authString)) { return Task.CompletedTask; }
                if (string.IsNullOrWhiteSpace(authString)) { return Task.CompletedTask; }
                string token = string.Empty;
                if (authString.ToString().StartsWith($"{JwtHelper.Type} ", StringComparison.OrdinalIgnoreCase)) { token = authString.ToString()[$"{JwtHelper.Type} ".Length..].Trim(); }
                LoginUserModel user = JwtHelper.DeserializeToken(token);
                var empUser = redis.Get<LoginModel>($"{FrameworkEnum.UserType.Employee.ToString().ToUpper()}-{user.UserID}");
                if (empUser == null) { return Task.CompletedTask; }
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
