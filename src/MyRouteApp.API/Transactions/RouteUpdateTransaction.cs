using MediatR;
using MyRouteApp.API.Helpers;
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
    public class RouteUpdateTransaction : BaseTransaction, IRequestHandler<RouteUpdateTransactionRequest, RouteUpdateTransactionResponse>
    {
        public RouteUpdateTransaction(IRouteRepository RouteRepository) : base(RouteRepository)
        {
        }

        public async Task<RouteUpdateTransactionResponse> Handle(RouteUpdateTransactionRequest request, CancellationToken cancellationToken)
        {
            var Route = await RouteRepository.Update(
                Conversions.FromModelToDTO(request.Route)
                , cancellationToken);
            RouteUpdateTransactionResponse response = new RouteUpdateTransactionResponse();
            response.Route = Conversions.FromDTOToModel(Route);
            return response;
        }
    }
}
