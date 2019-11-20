using Microsoft.EntityFrameworkCore;
using MyRouteApp.Infrastructure.Exceptions;
using MyRouteApp.Infrastructure.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRouteApp.Infrastructure.Persistence.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly AppDbContext context;

        public RouteRepository(AppDbContext context)
        {
            this.context = context;
        }
        private IQueryable<Route> DefaultQueryRoutes()
        {
            return context.Routes.Include(x => x.DestinationPoint).Include(x => x.OriginalPoint);
        }

        public async Task<IEnumerable<Route>> GetAll(CancellationToken cancellationToken)
        {
            var result = await DefaultQueryRoutes().ToListAsync(cancellationToken);
            return result;
        }

        public async Task<Route> GetbyId(int id, CancellationToken cancellationToken)
        {
            var route = await DefaultQueryRoutes().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (route == null)
                throw new NotFoundException("Point");
            return route;
        }

        public async Task<Route> Add(Route route, CancellationToken cancellationToken)
        {
            await context.Routes.AddAsync(route, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return await GetbyId(route.Id, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var route = await this.GetbyId(id, cancellationToken);
            context.Routes.Remove(route);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Route> Update(Route route, CancellationToken cancellationToken)
        {
            var routeResult = await this.GetbyId(route.Id, cancellationToken);
            routeResult.Time = route.Time;
            routeResult.Cost = route.Cost;
            routeResult.DestinationPointId = route.DestinationPointId;
            routeResult.OriginalPointId = route.OriginalPointId;
            await context.SaveChangesAsync(cancellationToken);
            return await this.GetbyId(route.Id, cancellationToken);
        }
    }
}
