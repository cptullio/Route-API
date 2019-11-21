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
    public class CheapestPathTransaction : BasePathTransaction, IRequestHandler<CheapestPathTransactionRequest, CheapestPathTransactionResponse>
    {
        public CheapestPathTransaction(IRouteRepository routeRepository) : base(routeRepository)
        {
        }

        public async Task<CheapestPathTransactionResponse> Handle(CheapestPathTransactionRequest request, CancellationToken cancellationToken)
        {
            var routes = await RouteRepository.GetAll(cancellationToken);
            ConfirmPoint(routes, request.PathModel);
            var fullPath = this.OriginalPoint.FindShortestPath(this.DestinationPoint);
            if (fullPath == null)
                throw new NotFoundException("Path");
            return new CheapestPathTransactionResponse() { FullPath = Conversions.FromDomainPathToModel(fullPath) };
        }
    }
}
