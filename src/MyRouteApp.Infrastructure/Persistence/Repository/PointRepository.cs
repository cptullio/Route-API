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
    public class PointRepository : IPointRepository
    {
        private readonly AppDbContext context;

        public PointRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Point>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Points.ToListAsync(cancellationToken);
        }

        public async Task<Point> GetbyId(int id, CancellationToken cancellationToken)
        {
            var point = await context.Points.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (point == null)
                throw new NotFoundException("Point");
            return point;
        }

        public async Task<Point> Add(Point point, CancellationToken cancellationToken)
        {
            await context.Points.AddAsync(point, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return point;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var point = await this.GetbyId(id, cancellationToken);
            context.Points.Remove(point);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Point> Update(int id, string name, CancellationToken cancellationToken)
        {
            var point = await this.GetbyId(id, cancellationToken);
            point.Name = name;
            await context.SaveChangesAsync(cancellationToken);
            return point;
        }
    }
}
