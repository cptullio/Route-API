using MediatR;
using MyRouteApp.API.Helpers;
using MyRouteApp.API.Model;
using MyRouteApp.API.Transactions.Path;
using MyRouteApp.Infrastructure.Exceptions;
using MyRouteApp.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyRouteApp.API.Transactions
{
    public abstract class BasePathTransaction : BaseTransaction
    {
        public BasePathTransaction(IRouteRepository routeRepository) : base(routeRepository)
        {
        }

        public Domain.Point OriginalPoint { get; set; }
        public Domain.Point DestinationPoint { get; set; }

        protected void ConfirmPoint(IEnumerable<Infrastructure.Persistence.DTO.Route> routes, PathModel pathModel)
        {
            var graph = Conversions.FromDTORoutesToGraph(routes);
            OriginalPoint = graph.Where(x => x.Id == pathModel.OriginalPointId).FirstOrDefault();
            DestinationPoint = graph.Where(x => x.Id == pathModel.DestinationPointId).FirstOrDefault();
            if (OriginalPoint == null)
                throw new NotFoundException("Original Point in Graph");
            if (DestinationPoint == null)
                throw new NotFoundException("Destination Point in Graph");
        }

    }
}
