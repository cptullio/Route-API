using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyIdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();


            var myApiClient = new Client()
            {
                ClientId = "myclient",
                 AllowedCorsOrigins = { "https://localhost:5001/" },
                ClientName = "My Route API Client Access",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                ClientSecrets =
                   {
                       new Secret("SecretKeyOftheClient")
                   },
                AllowedScopes =
                   {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       "API"
                   }
            };
            var testUser = new TestUser()
            {
                SubjectId = "c7371bd8-0726-4b89-ac57-0e220ffc404f",
                Username = "user",
                Password = "1234",
                Claims = new List<Claim>()
               {
                   new Claim("name", "Tester User"),
                   new Claim(ClaimTypes.Role,"user")
               },
            };
            var testAdmin = new TestUser()
            {
                SubjectId = "7d122680-448f-4a77-bc0e-0d382c6d3ffa",
                Username = "admin",
                Password = "1234",
                Claims = new List<Claim>()
               {
                   new Claim("name", "Tester Admin"),
                   new Claim(ClaimTypes.Role,"admin")
               },
            };
            services.AddCors();

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddJwtBearerClientAuthentication()
                    .AddInMemoryClients(new[] { myApiClient })
                    .AddInMemoryApiResources(new[] { new ApiResource("API", "Api Resources") })
                    .AddInMemoryIdentityResources(new[] { new IdentityResources.OpenId() })
                    .AddTestUsers(new List<TestUser>() { testUser, testAdmin });
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseIdentityServer();
        }
    }
}
