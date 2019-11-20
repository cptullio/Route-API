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
    public class PointListTransaction : BaseTransaction, IRequestHandler<PointListTransactionRequest, PointListTransactionResponse>
    {
        public PointListTransaction(IPointRepository pointRepository) : base(pointRepository)
        {
        }

        public async Task<PointListTransactionResponse> Handle(PointListTransactionRequest request, CancellationToken cancellationToken)
        {
            var points = await PointRepository.GetAll(cancellationToken);
            PointListTransactionResponse response = new PointListTransactionResponse();
            response.PointList = points.Select(x => new Model.PointModel() { Id = x.Id, Name = x.Name }).ToList();
            return response;
        }
    }
}
