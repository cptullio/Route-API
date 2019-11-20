using MediatR;

namespace MyRouteApp.API.Transactions.Point
{
    public class PointCreateTransactionRequest : IRequest<PointUpdateTransactionResponse>
    {
        public string Name { get; set; }
    }
}