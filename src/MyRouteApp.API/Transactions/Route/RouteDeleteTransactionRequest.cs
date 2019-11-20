using MediatR;

namespace MyRouteApp.API.Transactions.Route
{
    public class RouteDeleteTransactionRequest : IRequest
    {
        public int Id { get; set; }
    }
}