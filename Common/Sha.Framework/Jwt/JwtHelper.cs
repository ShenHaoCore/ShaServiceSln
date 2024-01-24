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
        /// <param name="info"></param>
        /// <returns></returns>
        public static string GenerateToken(AuthenInfoModel info)
        {
            var jwt = AppSettingHelper.GetObject<JwtConfig>(JwtConfig.KEY);
            if (jwt == null) { throw new ArgumentNullException(nameof(jwt)); }
            IEnumerable<Claim> claims = new Claim[] { new Claim(JwtRegisteredClaimNames.Jti, info.UserID.ToString()), new Claim(ClaimTypes.Role, info.Role) };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey));
            SigningCredentials sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtoken = new JwtSecurityToken(issuer: jwt.Issuer, audience: jwt.Audience, claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddSeconds(Expiry.TotalSeconds), signingCredentials: sign);
            return new JwtSecurityTokenHandler().WriteToken(jwtoken);
        }

        /// <summary>
        /// 解析令牌
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static AuthenInfoModel DeserializeToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            if (string.IsNullOrWhiteSpace(token)) { return new AuthenInfoModel(); }
            if (!handler.CanReadToken(token)) { return new AuthenInfoModel(); }
            AuthenInfoModel user = new AuthenInfoModel();
            JwtSecurityToken jwtoken = handler.ReadJwtToken(token);
            if (long.TryParse(jwtoken.Id, out long uid)) { user.UserID = uid; }
            if (jwtoken.Payload.TryGetValue(ClaimTypes.Role, out object? role)) { user.Role = role.ObjToString(); }
            return user;
        }
    }
}
