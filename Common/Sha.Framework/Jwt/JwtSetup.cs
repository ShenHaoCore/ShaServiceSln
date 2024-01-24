using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

            var jwt = AppSettingHelper.GetObject<JwtConfig>(JwtConfig.KEY);
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
                ClockSkew = TimeSpan.FromSeconds(30), // 时钟偏移
                RequireExpirationTime = true
            };

            services.AddAuthorization(options =>
            {
                options.AddPolicy("OnlyEmployee", Policy => Policy.Requirements.Add(new EmployeeRequirement()));
                options.AddPolicy("OnlyCustomer", Policy => Policy.Requirements.Add(new CustomerRequirement()));
            }); 
            services.AddScoped<IAuthorizationHandler, EmployeeHandler>();
            services.AddScoped<IAuthorizationHandler, CustomerHandler>();

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
        /// 如果授权失败并导致禁止响应，则调用
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
        /// 在安全令牌已通过验证并生成 ClaimsIdentity 后调用
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task TokenValidated(TokenValidatedContext context)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 首次收到协议消息时调用
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task MessageReceived(MessageReceivedContext context)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 在质询发送回调用方之前调用
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
        /// 如果在请求处理期间身份验证失败，则调用。 在发生此事件后将重新引发异常，除非已抑制这些异常
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            return Task.CompletedTask;
        }
    }
}
