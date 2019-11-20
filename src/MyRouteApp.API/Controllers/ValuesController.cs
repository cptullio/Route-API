using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyRouteApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Authorize()]
        public ActionResult<IEnumerable<string>> Get()
        {
            var s = new List<String>();
            s.Add(User.Identity.Name);
            s.Add("IsAdmin: " + User.IsInRole("admins").ToString());
            s.Add("IsUser: " + User.IsInRole("users").ToString());
            foreach (var item in User.Claims)
            {
                s.Add(item.Type + " - " + item.Value);
            }
            
            return s;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Roles="admin")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
