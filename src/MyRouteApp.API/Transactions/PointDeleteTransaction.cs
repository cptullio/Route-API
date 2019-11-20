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
    public class PointDeleteTransaction : BaseTransaction, IRequestHandler<PointDeleteTransactionRequest>
    {
        public PointDeleteTransaction(IPointRepository pointRepository) : base(pointRepository)
        {
        }

        public async Task<Unit> Handle(PointDeleteTransactionRequest request, CancellationToken cancellationToken)
        {
            var success = await PointRepository.Delete(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
