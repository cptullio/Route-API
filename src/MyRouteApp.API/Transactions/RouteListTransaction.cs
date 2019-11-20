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
    public class RouteListTransaction : BaseTransaction, IRequestHandler<RouteListTransactionRequest, RouteListTransactionResponse>
    {
        public RouteListTransaction(IRouteRepository RouteRepository) : base(RouteRepository)
        {
        }

        public async Task<RouteListTransactionResponse> Handle(RouteListTransactionRequest request, CancellationToken cancellationToken)
        {
            var Routes = await RouteRepository.GetAll(cancellationToken);
            RouteListTransactionResponse response = new RouteListTransactionResponse();
            response.RouteList = 
                Routes.Select(x =>  Conversions.FromDTOToModel(x)).ToList();
            return response;
        }
    }
}
