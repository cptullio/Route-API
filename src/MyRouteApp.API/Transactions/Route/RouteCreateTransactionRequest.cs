using MediatR;
using MyRouteApp.API.Model;

namespace MyRouteApp.API.Transactions.Route
{
    public class RouteCreateTransactionRequest : IRequest<RouteUpdateTransactionResponse>
    {
        public RouteModel Route { get; set; }
    }
}