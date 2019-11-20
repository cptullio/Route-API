using MediatR;
using MyRouteApp.API.Transactions.Point;
using MyRouteApp.Infrastructure.Exceptions;
using MyRouteApp.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyRouteApp.API.Transactions
{
    public class PointUpdateTransaction : BaseTransaction, IRequestHandler<PointUpdateTransactionRequest, PointUpdateTransactionResponse>
    {
        public PointUpdateTransaction(IPointRepository pointRepository) : base(pointRepository)
        {
        }

        public async Task<PointUpdateTransactionResponse> Handle(PointUpdateTransactionRequest request, CancellationToken cancellationToken)
        {
            var point = await PointRepository.Update(request.Point.Id, request.Point.Name, cancellationToken);
            PointUpdateTransactionResponse response = new PointUpdateTransactionResponse();
            response.Point = new Model.PointModel() { Id = point.Id, Name = point.Name };
            return response;
        }
    }
}
