using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyRouteApp.Infrastructure.Persistence.DTO
{
    public class Point
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Route> OriginalRouteList { get; set; }
        public List<Route> DestinationRouteList { get; set; }
    }
}
