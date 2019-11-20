using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MyRouteApp.IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var secret = "123456789".ToSha256();

            var myApiClient = new Client()
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
            };
            var testUser = new TestUser()
            {
                SubjectId = "c7371bd8-0726-4b89-ac57-0e220ffc404f",
                Username = "user",
                Password = "1234",
                Claims = new List<Claim>()
               {
                   new Claim(ClaimTypes.Name, "Tester User"),
                   new Claim(ClaimTypes.Role,"users")
               },
            };
            var testAdmin = new TestUser()
            {
                SubjectId = "7d122680-448f-4a77-bc0e-0d382c6d3ffa",
                Username = "admin",
                Password = "1234",
                Claims = new List<Claim>()
               {
                   new Claim(ClaimTypes.Name, "Tester Admin"),
                   new Claim(ClaimTypes.Role,"admins")
               },
            };

            var apiResources = new List<ApiResource>
            {
                new ApiResource()
                {
                    Name = "IdServer",
                    ApiSecrets =
                    {
                        new Secret(secret)
                    },
                    
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

            var identityResources = new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
            services.AddCors();

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryClients(new[] { myApiClient })
                    .AddInMemoryApiResources(apiResources)
                    .AddInMemoryIdentityResources(identityResources)
                    .AddTestUsers(new List<TestUser>() { testUser, testAdmin });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseIdentityServer();
        }
    }
}
