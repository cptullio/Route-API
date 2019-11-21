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
    public class AllPathsTransaction : BasePathTransaction, IRequestHandler<AllPathsTransactionRequest, AllPathsTransactionResponse>
    {
        public AllPathsTransaction(IRouteRepository routeRepository) : base(routeRepository)
        {
        }

        public async Task<AllPathsTransactionResponse> Handle(AllPathsTransactionRequest request, CancellationToken cancellationToken)
        {
            var routes = await RouteRepository.GetAll(cancellationToken);
            ConfirmPoint(routes, request.PathModel);
            var fullPath = this.OriginalPoint.FindPaths(this.DestinationPoint);
            if (fullPath == null || fullPath.Count() == 0)
                throw new NotFoundException("Path");
            return new AllPathsTransactionResponse() { FullPathList = fullPath.Select(x=> Conversions.FromDomainPathToModel(x)).ToList() };
        }
    }
}
