using Microsoft.EntityFrameworkCore;
using MyRouteApp.Infrastructure.Persistence.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRouteApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            if (!Database.IsInMemory() && Database.GetPendingMigrations().Any())
                Database.Migrate();
        }

        public DbSet<Point> Points { get; private set; }
        public DbSet<Route> Routes { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            var pointBuilder = modelBuilder.Entity<Point>();

            var routeBuilder = modelBuilder.Entity<Route>();
            routeBuilder.HasOne<Point>(x => x.OriginalPoint).WithMany(x => x.OriginalRouteList).HasForeignKey(x => x.OriginalPointId).IsRequired();
            routeBuilder.HasOne<Point>(x => x.DestinationPoint).WithMany(x => x.DestinationRouteList).HasForeignKey(x => x.DestinationPointId).IsRequired();
            routeBuilder.HasIndex(e => new { e.DestinationPointId, e.OriginalPointId }).IsUnique();

            
            Point[] points = new [] {
                new Point() {Id=1, Name = "A" },
                new Point() {Id=2, Name = "B" },
                new Point() {Id=3, Name = "C" },
                new Point() {Id=4, Name = "D" },
                new Point() {Id=5, Name = "E" },
                new Point() {Id=6, Name = "F" },
                new Point() {Id=7, Name = "G" },
                new Point() {Id=8, Name = "H" },
                new Point() {Id=9, Name = "I" }
            };

            Route[] routes = new []
            {
                new Route() {Id=1, OriginalPointId = 1, DestinationPointId = 3, Cost = 20, Time = 1 },
                new Route() {Id=2, OriginalPointId = 1, DestinationPointId = 8, Cost = 10, Time = 1 },
                new Route() {Id=3, OriginalPointId = 1, DestinationPointId = 5, Cost = 30, Time = 5 },
                new Route() {Id=4, OriginalPointId = 3, DestinationPointId = 2, Cost = 12, Time = 1 },
                new Route() {Id=5, OriginalPointId = 8, DestinationPointId = 5, Cost = 1, Time = 30 },
                new Route() {Id=6, OriginalPointId = 5, DestinationPointId = 4, Cost = 5, Time = 3 },
                new Route() {Id=7, OriginalPointId = 4, DestinationPointId = 6, Cost = 50, Time = 4 },
                new Route() {Id=8, OriginalPointId = 6, DestinationPointId = 9, Cost = 50, Time = 45 },
                new Route() {Id=9, OriginalPointId = 6, DestinationPointId = 8, Cost = 50, Time = 40 },
                new Route() {Id=10, OriginalPointId = 7, DestinationPointId = 2, Cost = 73, Time = 64 },
                new Route() {Id=11, OriginalPointId = 9, DestinationPointId = 2, Cost = 5, Time = 64 },
            };

            pointBuilder.HasData(points);
            routeBuilder.HasData(routes);

            base.OnModelCreating(modelBuilder);
        }
        

    }

}
