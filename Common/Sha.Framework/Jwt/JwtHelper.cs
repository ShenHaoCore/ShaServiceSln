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
        /// <summary>
        /// 
        /// </summary>
        public readonly static string Type = "Bearer";

        /// <summary>
        /// 有效期
        /// </summary>
        public readonly static TimeSpan Expiry = new TimeSpan(0, 30, 0);

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string GenerateToken(TokenInfoModel info)
        {
            var setting = AppSettingHelper.GetObject<JwtSetting>(JwtSetting.KEY);
            ArgumentNullException.ThrowIfNull(setting);
            IEnumerable<Claim> claims = new Claim[] { 
                new Claim(JwtRegisteredClaimNames.Jti, info.UserID.ToString()), 
                new Claim(ClaimTypes.Role, info.Role) 
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.SecretKey));
            SigningCredentials sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtoken = new JwtSecurityToken(issuer: setting.Issuer, audience: setting.Audience, claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddSeconds(Expiry.TotalSeconds), signingCredentials: sign);
            return new JwtSecurityTokenHandler().WriteToken(jwtoken);
        }

        /// <summary>
        /// 解析令牌
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static TokenInfoModel DeserializeToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            if (string.IsNullOrWhiteSpace(token)) { return new TokenInfoModel(); }
            if (!handler.CanReadToken(token)) { return new TokenInfoModel(); }
            TokenInfoModel info = new TokenInfoModel();
            JwtSecurityToken jwtoken = handler.ReadJwtToken(token);
            if (long.TryParse(jwtoken.Id, out long uid)) { info.UserID = uid; }
            if (jwtoken.Payload.TryGetValue(ClaimTypes.Role, out object? role)) { info.Role = role.ObjToString(); }
            return info;
        }
    }
}
