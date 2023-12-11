using Microsoft.AspNetCore.Authorization;
using Sha.Framework.Redis;

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
            return Task.CompletedTask;
        }
    }
}
