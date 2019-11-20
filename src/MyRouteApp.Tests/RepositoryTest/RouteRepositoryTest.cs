using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;
using System.Linq;
using MyRouteApp.Infrastructure.Persistence.Repository;

namespace MyRouteApp.Tests.RepositoryTest
{
    [TestClass]
    public class RouteRepositoryTest : RepositoryBaseTest
    {
        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        [TestCleanup]
        public async Task CleanUp()
        {
            var token = new System.Threading.CancellationToken();
            IRouteRepository repository = Provider.GetService<IRouteRepository>();
            var routes = await repository.GetAll(token);
            foreach (var item in routes)
            {
                await repository.Delete(item.Id, token);
            }
        }

        [TestMethod]
        public async Task CreateRouteTest()
        {
            var token = new System.Threading.CancellationToken();
            IRouteRepository repository = Provider.GetService<IRouteRepository>();
            var route = new Infrastructure.Persistence.DTO.Route() { OriginalPoint = new Infrastructure.Persistence.DTO.Point { Name = "A" }, DestinationPoint = new Infrastructure.Persistence.DTO.Point { Name = "C" },  Cost = 10, Time = 1 };
            var point = await repository.Add(route, token);
            Assert.IsNotNull(point);
        }


        [TestMethod]
        public async Task GetRoutesTest()
        {
            var token = new System.Threading.CancellationToken();
            IRouteRepository repository = Provider.GetService<IRouteRepository>();
            await repository.Add(
                    new Infrastructure.Persistence.DTO.Route() { OriginalPoint = new Infrastructure.Persistence.DTO.Point { Name = "A" }, 
                        DestinationPoint = new Infrastructure.Persistence.DTO.Point {  Name = "C" }, 
                        Cost = 10, Time = 1 },
                     token);
            await repository.Add(
                    new Infrastructure.Persistence.DTO.Route()
                    {
                        OriginalPoint = new Infrastructure.Persistence.DTO.Point {  Name = "A" },
                        DestinationPoint = new Infrastructure.Persistence.DTO.Point {  Name = "B" },
                        Cost = 10,
                        Time = 1
                    },
                     token);
            await repository.Add(
                    new Infrastructure.Persistence.DTO.Route()
                    {
                        OriginalPoint = new Infrastructure.Persistence.DTO.Point {  Name = "A" },
                        DestinationPoint = new Infrastructure.Persistence.DTO.Point {Name = "D" },
                        Cost = 10,
                        Time = 1
                    },
                     token);
            var routes = await repository.GetAll(token);
            Assert.AreEqual(3, routes.Count());
        }
    }
}
