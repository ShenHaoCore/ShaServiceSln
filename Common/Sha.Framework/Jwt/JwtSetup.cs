using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Sha.Framework.Base;
using Sha.Framework.Common;
using Sha.Framework.Enum;
using System.Text;

namespace Sha.Framework.Jwt
{
    /// <summary>
    /// JWT启动服务
    /// </summary>
    public static class JwtSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddJwtSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(nameof(services));

            JwtConfig? jwt = AppSettings.GetObject<JwtConfig>(JwtConfig.KEY);
            if (jwt == null) { throw new ArgumentNullException(nameof(jwt)); }

            TokenValidationParameters tokenParam = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwt.Issuer,
                ValidateAudience = true,
                ValidAudience = jwt.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey)),
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(option =>
            {
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = tokenParam;
                option.Events = new JwtBearerEvents
                {
                    OnTokenValidated = TokenValidated,
                    OnMessageReceived = MessageReceived,
                    OnChallenge = Challenge,
                    OnAuthenticationFailed = AuthenticationFailed,
                    OnForbidden = Forbidden
                };
            });
        }

        /// <summary>
        /// 权限不足
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task Forbidden(ForbiddenContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse(false, FrameworkEnum.StatusCode.Forbidden)));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task TokenValidated(TokenValidatedContext context)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 接收到请时触发
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task MessageReceived(MessageReceivedContext context)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 权限验证失败
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task Challenge(JwtBearerChallengeContext context)
        {
            context.HandleResponse();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse(false, FrameworkEnum.StatusCode.UnAuthorized)));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 验证JWT数据失败时触发
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            context.Response.ContentType = "application/json";
            return Task.CompletedTask;
        }
    }
}
