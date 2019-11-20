using MediatR;
using MyRouteApp.API.Transactions.Route;
using MyRouteApp.Infrastructure.Exceptions;
using MyRouteApp.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyRouteApp.API.Transactions
{
    public class RouteDeleteTransaction : BaseTransaction, IRequestHandler<RouteDeleteTransactionRequest>
    {
        public RouteDeleteTransaction(IRouteRepository RouteRepository) : base(RouteRepository)
        {
        }

        public async Task<Unit> Handle(RouteDeleteTransactionRequest request, CancellationToken cancellationToken)
        {
            var success = await RouteRepository.Delete(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
