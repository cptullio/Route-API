﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRouteApp.Infrastructure.Persistence;

namespace MyRouteApp.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191121123911_seed-route-fix-data")]
    partial class seedroutefixdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("MyRouteApp.Infrastructure.Persistence.DTO.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Points");

                    b.HasData(
                        new { Id = 1, Name = "A" },
                        new { Id = 2, Name = "B" },
                        new { Id = 3, Name = "C" },
                        new { Id = 4, Name = "D" },
                        new { Id = 5, Name = "E" },
                        new { Id = 6, Name = "F" },
                        new { Id = 7, Name = "G" },
                        new { Id = 8, Name = "H" },
                        new { Id = 9, Name = "I" }
                    );
                });

            modelBuilder.Entity("MyRouteApp.Infrastructure.Persistence.DTO.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cost");

                    b.Property<int>("DestinationPointId");

                    b.Property<int>("OriginalPointId");

                    b.Property<int>("Time");

                    b.HasKey("Id");

                    b.HasIndex("OriginalPointId");

                    b.HasIndex("DestinationPointId", "OriginalPointId")
                        .IsUnique();

                    b.ToTable("Routes");

                    b.HasData(
                        new { Id = 1, Cost = 20, DestinationPointId = 3, OriginalPointId = 1, Time = 1 },
                        new { Id = 2, Cost = 10, DestinationPointId = 8, OriginalPointId = 1, Time = 1 },
                        new { Id = 3, Cost = 30, DestinationPointId = 5, OriginalPointId = 1, Time = 5 },
                        new { Id = 4, Cost = 12, DestinationPointId = 2, OriginalPointId = 3, Time = 1 },
                        new { Id = 5, Cost = 1, DestinationPointId = 5, OriginalPointId = 8, Time = 30 },
                        new { Id = 6, Cost = 5, DestinationPointId = 4, OriginalPointId = 5, Time = 3 },
                        new { Id = 7, Cost = 50, DestinationPointId = 6, OriginalPointId = 4, Time = 4 },
                        new { Id = 8, Cost = 50, DestinationPointId = 9, OriginalPointId = 6, Time = 45 },
                        new { Id = 9, Cost = 50, DestinationPointId = 8, OriginalPointId = 6, Time = 40 },
                        new { Id = 10, Cost = 73, DestinationPointId = 2, OriginalPointId = 7, Time = 64 },
                        new { Id = 11, Cost = 5, DestinationPointId = 2, OriginalPointId = 9, Time = 64 }
                    );
                });

            modelBuilder.Entity("MyRouteApp.Infrastructure.Persistence.DTO.Route", b =>
                {
                    b.HasOne("MyRouteApp.Infrastructure.Persistence.DTO.Point", "DestinationPoint")
                        .WithMany("DestinationRouteList")
                        .HasForeignKey("DestinationPointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyRouteApp.Infrastructure.Persistence.DTO.Point", "OriginalPoint")
                        .WithMany("OriginalRouteList")
                        .HasForeignKey("OriginalPointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
