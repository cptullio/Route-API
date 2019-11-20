using System;
using System.Collections.Generic;
using System.Text;

namespace MyRouteApp.Domain
{
    public class Route
    {
        public int Id { get; set; }
        public Point DestinationPoint { get; internal set; }
        public int Cost { get; internal set; }
        public int Time { get; internal set; }
        public Route(Point destination, int cost, int time)
        {
            DestinationPoint = destination;
            Cost = cost;
            Time = time;
        }

    }
}
