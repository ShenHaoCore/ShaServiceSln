using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Sha.Framework.Enum;
using Sha.Framework.Redis;
using System.Security.Claims;

namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerRequirementHandler : AuthorizationHandler<CustomerRequirement>
    {
        private readonly IRedisManage redis;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redis"></param>
        public CustomerRequirementHandler(IRedisManage redis)
        {
            this.redis = redis;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerRequirement requirement)
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
                JwtUserModel user = JwtHelper.DeserializeToken(token);
                var cusUser = redis.Get<LoginUser>($"{FrameworkEnum.UserType.Customer.ToString().ToUpper()}-{user.UserID}");
                if (cusUser == null) { return Task.CompletedTask; }
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
