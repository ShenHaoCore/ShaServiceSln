using Microsoft.AspNetCore.Authorization;
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
            if (context.Resource is DefaultHttpContext)
            {
                var httpContext = context.Resource as DefaultHttpContext;
                var questPath = httpContext?.Request?.Path;
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
