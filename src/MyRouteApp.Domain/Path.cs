using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MyRouteApp.Domain
{
    public class Path
    {
        public Point OriginalPoint { get; set; }
        public Route Destination { get; set; }
    }
}
