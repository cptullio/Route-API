using MyRouteApp.Infrastructure.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRouteApp.Infrastructure.Persistence.Repository
{
    public interface IPointRepository
    {
        Task<IEnumerable<Point>> GetAll(CancellationToken cancellationToken);
        Task<Point> GetbyId(int id, CancellationToken cancellationToken);
        Task<Point> Add(Point point, CancellationToken cancellationToken);
        Task<Point> Update(int id, string Name, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
