using MediatR;
using MyRouteApp.API.Helpers;
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
    public class FastestPathTransaction : BaseTransaction, IRequestHandler<PathTransactionRequest, PathTransactionResponse>
    {
        public FastestPathTransaction(IPointRepository pointRepository, IRouteRepository routeRepository) : base(pointRepository, routeRepository)
        {
        }

        public async Task<PathTransactionResponse> Handle(PathTransactionRequest request, CancellationToken cancellationToken)
        {
            var routes = await RouteRepository.GetAll(cancellationToken);
            var graph = Conversions.FromDTORoutesToGraph(routes);
            var pointOriginal = graph.Where(x => x.Id == request.PathModel.OriginalPointId).FirstOrDefault();
            var pointDestination = graph.Where(x => x.Id == request.PathModel.DestinationPointId).FirstOrDefault();
            if (pointOriginal == null)
                throw new NotFoundException("Original Point in Graph");
            if (pointDestination == null)
                throw new NotFoundException("Destination Point in Graph");
            var fullPath = pointOriginal.FindShortestPath(pointDestination);
            if (fullPath == null)
                throw new NotFoundException("Path");
            PathTransactionResponse response = new PathTransactionResponse();
            response.FullPath = Conversions.FromDomainPathToModel(fullPath);
            return response;

        }
    }
}
