using Microsoft.IdentityModel.Tokens;
using Sha.Framework.Common;
using SqlSugar.Extensions;
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
        /// <summary>
        /// 
        /// </summary>
        public static string Type { get; set; } = "Bearer";

        /// <summary>
        /// 颁发
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string IssueToken(JwtUserModel user)
        {
            JwtConfig? jwtConfig = AppSettings.GetObject<JwtConfig>(JwtConfig.KEY);
            if (jwtConfig == null) { throw new ArgumentNullException(nameof(jwtConfig)); }

            IEnumerable<Claim> claims = new Claim[] { new Claim(JwtRegisteredClaimNames.Jti, user.Uid.ToString()), new Claim(ClaimTypes.Role, user.Role) };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            SigningCredentials sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtoken = new JwtSecurityToken(issuer: jwtConfig.Issuer, audience: jwtConfig.Audience, claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddSeconds(1000), signingCredentials: sign);
            return new JwtSecurityTokenHandler().WriteToken(jwtoken);
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JwtUserModel SerializeToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtUserModel user = new JwtUserModel();
            if (!string.IsNullOrWhiteSpace(token) && handler.CanReadToken(token))
            {
                JwtSecurityToken jwtoken = handler.ReadJwtToken(token);
                if (long.TryParse(jwtoken.Id, out long uid)) { user.Uid = uid; }
                if (jwtoken.Payload.TryGetValue(ClaimTypes.Role, out object? role)) { user.Role = role != null ? role.ObjToString() : ""; }
            }
            return user;
        }
    }
}
