using MyRouteApp.API.Model;
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

        public static List<Domain.Point> FromDTORoutesToGraph(IEnumerable<Route> routes)
        {
            List<Domain.Point> domainPoints = new List<Domain.Point>();
            List<Infrastructure.Persistence.DTO.Point> points = routes.Select(x => x.DestinationPoint).Distinct().ToList();
            points.AddRange(routes.Select(x => x.OriginalPoint).Distinct());
            domainPoints = points.Select(x => new Domain.Point(x.Id, x.Name)).Distinct().ToList();
            foreach (var item in routes)
            {
                var originPoint = domainPoints.Where(x => x.Id == item.OriginalPoint.Id).FirstOrDefault();
                var destinPoint = domainPoints.Where(x => x.Id == item.DestinationPoint.Id).FirstOrDefault();
                Domain.Route route = new Domain.Route(destinPoint, item.Cost, item.Time);
                originPoint.DestinationList.Add(route);
            }
            return domainPoints;
        }

        public static FullPathModel FromDomainPathToModel(Domain.FullPath fullPath)
        {
            FullPathModel model = new FullPathModel();
            model.PathList.AddRange(
                fullPath.PathList.Select(x =>
                new PathFoundModel()
                {
                    DestinationPoint = new PointModel() { Id = x.Destination.DestinationPoint.Id, Name = x.Destination.DestinationPoint.Name },
                    OriginalPoint = new PointModel() { Id = x.OriginalPoint.Id, Name = x.OriginalPoint.Name }
                }).ToList());
            model.TotalCost = fullPath.TotalCostofPath;
            return model;
        }
    }
}
