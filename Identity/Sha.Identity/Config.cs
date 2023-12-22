using IdentityServer4.Models;

namespace Sha.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> { new ApiScope("BaseService"), new ApiScope("UserService") };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>() { 
            new ApiResource("BaseService", "BaseService") { Scopes = { "BaseService" }, ApiSecrets = { new Secret("BaseService".Sha256()) } }, 
            new ApiResource("UserService", "UserService") { Scopes = { "UserService" }, ApiSecrets = { new Secret("UserService".Sha256()) } } 
        };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> Clients => new List<Client> { 
            new Client { 
                ClientId = "web_client", ClientName = "AuthCenter", AllowedGrantTypes = GrantTypes.ClientCredentials, 
                ClientSecrets = new[] { new Secret("Mamba24".Sha256()) }, AccessTokenLifetime = 3600, AllowedScopes = new List<string> { "BaseService", "UserService" }, 
                Claims = new List<ClientClaim>() { new ClientClaim(IdentityModel.JwtClaimTypes.Role, "Admin"), new ClientClaim(IdentityModel.JwtClaimTypes.NickName, "Mamba24"), } 
            } 
        };
    }
}
