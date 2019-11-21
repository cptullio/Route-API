using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRouteApp.API.Model
{
    public class PathModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int OriginalPointId { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int DestinationPointId { get; set; }
    }
}
