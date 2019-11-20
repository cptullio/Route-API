using MediatR;
using MyRouteApp.API.Model;

namespace MyRouteApp.API.Transactions.Point
{
    public class PointUpdateTransactionRequest : IRequest<PointUpdateTransactionResponse>
    {
        public PointModel Point { get; set; }
    }
}