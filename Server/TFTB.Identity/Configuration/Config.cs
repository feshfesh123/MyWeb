using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFTB.Identity.Configuration
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1", "openid", "profile"},
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                },
                new Client 
                {
                 ClientId = "angular_spa",
                 ClientName = "Angular SPA",
                 AllowedGrantTypes = GrantTypes.Implicit,
                 AllowedScopes = { "openid", "profile", "api1" },
                 RedirectUris = {"http://localhost:4200/auth-callback"},
                 PostLogoutRedirectUris = {"http://localhost:4200/"},
                 AllowedCorsOrigins = {"http://localhost:4200"},
                 AllowAccessTokensViaBrowser = true,
                 AccessTokenLifetime = 3600
                }
            };
        }
    }
}
