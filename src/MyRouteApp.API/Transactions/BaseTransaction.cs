using MyRouteApp.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRouteApp.API.Transactions
{
    public abstract class BaseTransaction
    {
        public BaseTransaction(IPointRepository pointRepository)
        {
            PointRepository = pointRepository;
            
        }
        public BaseTransaction(IRouteRepository routeRepository)
        {
            RouteRepository = routeRepository;
        }

        public BaseTransaction(IPointRepository pointRepository, IRouteRepository routeRepository)
        {
            PointRepository = pointRepository;
            RouteRepository = routeRepository;
        }
        public IRouteRepository RouteRepository { get;  }
        public IPointRepository PointRepository { get; }
    }
}
