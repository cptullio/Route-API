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
            
            if (Database.GetPendingMigrations().Any())
                Database.Migrate();
        }

        public DbSet<Point> Points { get; private set; }
        public DbSet<Route> Routes { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Point>();
            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasOne<Point>(x => x.OriginalPoint).WithMany(x => x.OriginalRouteList).HasForeignKey(x => x.OriginalPointId).IsRequired();
                entity.HasOne<Point>(x => x.DestinationPoint).WithMany(x => x.DestinationRouteList).HasForeignKey(x => x.DestinationPointId).IsRequired();

                entity.HasIndex(e => new { e.DestinationPointId, e.OriginalPointId }).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }

    }

}
