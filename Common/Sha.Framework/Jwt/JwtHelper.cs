using Microsoft.IdentityModel.Tokens;
using Sha.Common.Extension;
using Sha.Framework.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sha.Framework.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtHelper
    {
        public readonly static string Type = "Bearer";
        public readonly static TimeSpan Expiry = new TimeSpan(0, 30, 0); // 有效期

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GenerateToken(LoginUserModel user)
        {
            var jwtConfig = AppSettingHelper.GetObject<JwtConfig>(JwtConfig.KEY);
            if (jwtConfig == null) { throw new ArgumentNullException(nameof(jwtConfig)); }
            IEnumerable<Claim> claims = new Claim[] { new Claim(JwtRegisteredClaimNames.Jti, user.UserID.ToString()), new Claim(ClaimTypes.Role, user.Role) };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            SigningCredentials sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtoken = new JwtSecurityToken(issuer: jwtConfig.Issuer, audience: jwtConfig.Audience, claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddSeconds(Expiry.TotalSeconds), signingCredentials: sign);
            return new JwtSecurityTokenHandler().WriteToken(jwtoken);
        }

        /// <summary>
        /// 解析令牌
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static LoginUserModel DeserializeToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            if (string.IsNullOrWhiteSpace(token)) { return new LoginUserModel(); }
            if (!handler.CanReadToken(token)) { return new LoginUserModel(); }
            LoginUserModel user = new LoginUserModel();
            JwtSecurityToken jwtoken = handler.ReadJwtToken(token);
            if (long.TryParse(jwtoken.Id, out long uid)) { user.UserID = uid; }
            if (jwtoken.Payload.TryGetValue(ClaimTypes.Role, out object? role)) { user.Role = role.ObjToString(); }
            return user;
        }
    }
}
