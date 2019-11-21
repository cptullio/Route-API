using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRouteApp.API.Model
{
    public class PathFoundModel
    {
        public PointModel OriginalPoint { get; set; }
        public PointModel DestinationPoint { get; set; }
    }
}
