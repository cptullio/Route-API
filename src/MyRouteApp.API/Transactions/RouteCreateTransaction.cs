using MyRouteApp.API.Transactions.Route;
using MediatR;
using MyRouteApp.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyRouteApp.API.Helpers;

namespace MyRouteApp.API.Transactions
{
    public class RouteCreateTransaction : BaseTransaction, IRequestHandler<RouteCreateTransactionRequest, RouteUpdateTransactionResponse>
    {
        public RouteCreateTransaction(IRouteRepository RouteRepository) : base(RouteRepository)
        {
        }

        public async Task<RouteUpdateTransactionResponse> Handle(RouteCreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var Route = await RouteRepository.Add(
               Conversions.FromModelToDTO(request.Route),  cancellationToken);
            RouteUpdateTransactionResponse response = new RouteUpdateTransactionResponse();
            response.Route = Conversions.FromDTOToModel(Route);
            return response;
        }
    }
}
