using MediatR;

namespace MyRouteApp.API.Transactions.Point
{
    public class PointDeleteTransactionRequest : IRequest
    {
        public int Id { get; set; }
    }
}