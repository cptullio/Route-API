using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyRouteApp.Infrastructure.Persistence.DTO
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        public int OriginalPointId { get; set; }
        public virtual Point OriginalPoint { get; set; }
        public int DestinationPointId { get; set; }
        public virtual Point DestinationPoint { get; set; }
        public int Cost { get; set; }
        public int Time { get; set; }
    }
}
