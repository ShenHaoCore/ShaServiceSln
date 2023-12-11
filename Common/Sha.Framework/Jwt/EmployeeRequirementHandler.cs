using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeRequirementHandler : AuthorizationHandler<EmployeeRequirement>
    {
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
                string token = string.Empty;   if (authString.ToString().StartsWith($"Bearer ", StringComparison.OrdinalIgnoreCase)) { token = authString.ToString()["Bearer ".Length..].Trim(); }
                JwtUserModel user = JwtHelper.SerializeToken(authString.ToString());
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
