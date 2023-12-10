using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;

namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role);
            if (context.Resource is DefaultHttpContext)
            {
                var httpContext = context.Resource as DefaultHttpContext;
                if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }
                if (httpContext.Request == null) { throw new ArgumentNullException(nameof(httpContext.Request)); }
                var questPath = httpContext.Request.Path;
                if (!httpContext.Request.Headers.TryGetValue("Authorization", out StringValues token)) { return Task.CompletedTask; }
                JwtUserModel user = JwtHelper.SerializeToken(token.ToString());
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
