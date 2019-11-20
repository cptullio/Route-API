using MyRouteApp.API.Transactions.Point;
using MediatR;
using MyRouteApp.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyRouteApp.API.Transactions
{
    public class PointCreateTransaction : BaseTransaction, IRequestHandler<PointCreateTransactionRequest, PointUpdateTransactionResponse>
    {
        public PointCreateTransaction(IPointRepository pointRepository) : base(pointRepository)
        {
        }

        public async Task<PointUpdateTransactionResponse> Handle(PointCreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var point = await PointRepository.Add(new Infrastructure.Persistence.DTO.Point() { Name = request.Name  },  cancellationToken);
            PointUpdateTransactionResponse response = new PointUpdateTransactionResponse();
            response.Point = new Model.PointModel() { Id = point.Id, Name = point.Name };
            return response;
        }
    }
}
