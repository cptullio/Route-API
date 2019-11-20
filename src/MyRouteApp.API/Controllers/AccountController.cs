using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRouteApp.API.Model;
using static IdentityModel.OidcConstants;

namespace MyRouteApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        [HttpPost]
        public async Task<string> Post([FromBody] AutenticationInputModel model)
        {

            var client = new HttpClient();
            var secret = "123456789";
            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://localhost:5093/connect/token",
                ClientId = "myclient",
                ClientSecret =   secret,
                Scope = "IdServerScope",
                UserName = model.UserName,
                Password = model.Password,
                
                
            });

            return "Bearer " + response.AccessToken;

        }
    }


}
