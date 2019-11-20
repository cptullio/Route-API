using MediatR;
using MyRouteApp.API.Model;

namespace MyRouteApp.API.Transactions.Route
{
    public class RouteUpdateTransactionRequest : IRequest<RouteUpdateTransactionResponse>
    {
        public RouteModel Route { get; set; }
    }
}