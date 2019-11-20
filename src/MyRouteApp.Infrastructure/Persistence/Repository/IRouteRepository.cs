using MyRouteApp.Infrastructure.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRouteApp.Infrastructure.Persistence.Repository
{
    public interface IRouteRepository
    {
        Task<IEnumerable<Route>> GetAll(CancellationToken cancellationToken);
        Task<Route> GetbyId(int id, CancellationToken cancellationToken);
        Task<Route> Add(Route route, CancellationToken cancellationToken);
        Task<Route> Update(Route route, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
