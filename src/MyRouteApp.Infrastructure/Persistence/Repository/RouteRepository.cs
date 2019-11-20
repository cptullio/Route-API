using Microsoft.EntityFrameworkCore;
using MyRouteApp.Infrastructure.Exceptions;
using MyRouteApp.Infrastructure.Persistence.DTO;
using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Route>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Routes.ToListAsync(cancellationToken);
        }

        public async Task<Route> GetbyId(int id, CancellationToken cancellationToken)
        {
            var route = await context.Routes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (route == null)
                throw new NotFoundException("Point");
            return route;
        }

        public async Task<Route> Add(Route route, CancellationToken cancellationToken)
        {
            await context.Routes.AddAsync(route, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return route;
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
            routeResult.DestinationPoint = route.DestinationPoint;
            await context.SaveChangesAsync(cancellationToken);
            return routeResult;
        }
    }
}
