using MyRouteApp.Infrastructure.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRouteApp.API.Helpers
{
    public static class Conversions
    {
        public static Model.RouteModel FromDTOToModel(Route route)
        {
           return new Model.RouteModel()
            {
                Id = route.Id,
                DestinationPointId = route.DestinationPointId,
                OriginalPointId = route.OriginalPointId,
                Cost = route.Cost,
                Time = route.Time,
                DestinationPointName = route.DestinationPoint.Name,
                OriginalPointName = route.OriginalPoint.Name
            };
        }

        public static  Route FromModelToDTO(Model.RouteModel route)
        {
            return new Route()
            {
                Id = route.Id,
                DestinationPointId = route.DestinationPointId,
                OriginalPointId = route.OriginalPointId,
                Cost = route.Cost,
                Time = route.Time,
            };
        }

    }
}
