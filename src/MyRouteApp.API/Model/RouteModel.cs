using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRouteApp.API.Model
{
    public class RouteModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OriginalPointId{ get; set; }
        public string OriginalPointName { get; set; }
        [Required]
        public int DestinationPointId { get; set; }
        public string DestinationPointName { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Time { get; set; }

    }
}
