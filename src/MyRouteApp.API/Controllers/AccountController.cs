﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyRouteApp.API.Helpers;
using MyRouteApp.API.Model;
using static IdentityModel.OidcConstants;

namespace MyRouteApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IdentityServerConfigurationSettings IdentityServerConfiguration { get; }

        public AccountController(IdentityServerConfigurationSettings identityServerConfiguration)
        {
            IdentityServerConfiguration = identityServerConfiguration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] AutenticationInputModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                    {
                        Address = IdentityServerConfiguration.ServerUrl + "/connect/token",
                        ClientId = IdentityServerConfiguration.ClientId,
                        ClientSecret = IdentityServerConfiguration.ClientSecret,
                        Scope = IdentityServerConfiguration.Scope,
                        UserName = model.UserName,
                        Password = model.Password,
                    });

                    if (response.IsError)
                        throw new Exception(response.Error);
                    return Ok(new { token = response.AccessToken });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }


}
