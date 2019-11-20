using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyRouteApp.IdentityServer.Helpers
{
    public static class IdentityServerConfig
    {
        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static List<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource()
                {
                    Name = "IdServer",
                    Scopes =
                    {
                        new Scope
                        {

                            Name = "IdServerScope",
                            DisplayName = "Scope for the ApiResource"
                        }
                    },
                    UserClaims = { ClaimTypes.Name, ClaimTypes.Role }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
            new TestUser()
            {
                SubjectId = "c7371bd8-0726-4b89-ac57-0e220ffc404f",
                Username = "user",
                Password = "1234",
                Claims = new List<Claim>()
               {
                   new Claim(ClaimTypes.Name, "Tester User"),
                   new Claim(ClaimTypes.Role,"users")
               },
            },
            new TestUser()
            {
                SubjectId = "7d122680-448f-4a77-bc0e-0d382c6d3ffa",
                Username = "admin",
                Password = "1234",
                Claims = new List<Claim>()
               {
                   new Claim(ClaimTypes.Name, "Tester Admin"),
                   new Claim(ClaimTypes.Role,"admins")
               },
            }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            var secret = "123456789".ToSha256();
            return new[]{ new Client()
            {
                ClientId = "myclient",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 3600,
                IdentityTokenLifetime = 3600,
                UpdateAccessTokenClaimsOnRefresh = true,
                SlidingRefreshTokenLifetime = 30,
                AllowOfflineAccess = true,
                RefreshTokenExpiration = TokenExpiration.Absolute,
                RefreshTokenUsage = TokenUsage.OneTimeOnly,
                AlwaysSendClientClaims = true,
                Enabled = true,
                ClientSecrets =
                   {
                       new Secret(secret)
                   },
                AllowedScopes =
                   {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "IdServerScope"
                   }
            }};
        }
    }
}
