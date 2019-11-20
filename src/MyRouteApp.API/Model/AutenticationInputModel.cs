using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRouteApp.API.Model
{
    public class AutenticationInputModel
    {
        [Required]
        [MinLength(2)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
