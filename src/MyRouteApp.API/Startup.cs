using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using static IdentityModel.OidcConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using MyRouteApp.API.Helpers;
using System.Reflection;
using MediatR;
using MyRouteApp.Infrastructure.Persistence.Repository;
using MyRouteApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace MyRouteApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var identityServerConfigurationSettings = new IdentityServerConfigurationSettings();
            new ConfigureFromConfigurationOptions<IdentityServerConfigurationSettings>(
                Configuration.GetSection("IdentityServerConfig"))
                .Configure(identityServerConfigurationSettings);
            
            if (identityServerConfigurationSettings == null)
                throw new KeyNotFoundException("IdentityServerConfig");

            services.AddSingleton<IdentityServerConfigurationSettings>(identityServerConfigurationSettings);

            services.AddDbContext<AppDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("myRouteDB");
                if (string.IsNullOrEmpty(connectionString))
                    throw new Exception("Connection String not found!");
                options.UseSqlite(connectionString);

            });

            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = identityServerConfigurationSettings.ServerUrl;
                options.RequireHttpsMetadata = true;
                options.Audience = identityServerConfigurationSettings.Audience;
                
            });
            services.AddAuthorization();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Route APP Api",
                    Description = "Route APP Api",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Carlos Muniz",
                        Email = "cptullio@gmail.com"
                    },
                    License = new License
                    {
                        Name = "Demonstration License"
                    }
                   
                });
                string XMLPath = Path.Combine( 
                    PlatformServices.Default.Application.ApplicationBasePath, 
                    $"{PlatformServices.Default.Application.ApplicationName}.xml");
                
                c.IncludeXmlComments(XMLPath, true);

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",
                    
                }) ;
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                    {
                    {"Bearer",new string[]{}}
                    });
            });

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

            app.UseCors(builder =>
               builder
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

          
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Route API V1");
            });
        }
    }
}
