using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using MyRouteApp.Infrastructure.Persistence.Repository;
using MyRouteApp.Infrastructure.Persistence.DTO;
using MyRouteApp.API.Helpers;

namespace MyRouteApp.Tests.IntegrationTest
{
    [TestClass]
    public class FindPathIntegrationTest : RepositoryTest.RepositoryBaseTest
    {
        IRouteRepository repository;
        IPointRepository repositoryPoint;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
            repository = Provider.GetService<IRouteRepository>();
            repositoryPoint = Provider.GetService<IPointRepository>();
            
        }

        [TestCleanup]
        public async Task CleanUp()
        {
            var token = new System.Threading.CancellationToken();
            var routes = await repository.GetAll(token);
            foreach (var item in routes)
            {
                await repository.Delete(item.Id, token);
            }
            var points = await repositoryPoint.GetAll(token);
            foreach (var item in points)
            {
                await repositoryPoint.Delete(item.Id,token);
            }
        }

        [TestMethod]
        public async Task FindShortestPathFromRepositoryData()
        {
            await generatePoint();
            var token = new System.Threading.CancellationToken();
            var routes = await repository.GetAll(token);
            var domainPoints = Conversions.FromDTORoutesToGraph(routes);
            var pA = domainPoints.Where(x => x.Name == "A").FirstOrDefault();
            var pB = domainPoints.Where(x => x.Name == "B").FirstOrDefault();

            var fullPath = pA.FindShortestPath(pB);
            Assert.AreEqual(fullPath.PathList[0].OriginalPoint.Name, "A");
            Assert.AreEqual(fullPath.PathList[0].Destination.DestinationPoint.Name, "C");
            Assert.AreEqual(fullPath.PathList[1].OriginalPoint.Name, "C");
            Assert.AreEqual(fullPath.PathList[1].Destination.DestinationPoint.Name, "B");
            Assert.AreEqual(32, fullPath.TotalCostofPath);

            var pE = domainPoints.Where(x => x.Name == "E").FirstOrDefault();
            var pG = domainPoints.Where(x => x.Name == "G").FirstOrDefault();
            var result = pE.FindPaths(pG);
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Assert.AreEqual(1, result.Count);
        

    }


        public async Task generatePoint()
        {
            var token = new System.Threading.CancellationToken();
            var pA = await repositoryPoint.Add(new Point() { Name = "A" }, token);
            var pB = await repositoryPoint.Add(new Point() { Name = "B" }, token);
            var pC = await repositoryPoint.Add(new Point() { Name = "C" }, token);
            var pD = await repositoryPoint.Add(new Point() { Name = "D" }, token);
            var pE = await repositoryPoint.Add(new Point() { Name = "E" }, token);
            var pF = await repositoryPoint.Add(new Point() { Name = "F" }, token);
            var pG = await repositoryPoint.Add(new Point() { Name = "G" }, token);
            var pH = await repositoryPoint.Add(new Point() { Name = "H" }, token);
            var pI = await repositoryPoint.Add(new Point() { Name = "I" }, token);

            await repository.Add(new Route() { OriginalPoint = pA, DestinationPoint = pC, Cost = 20, Time = 1 }, token);
            await repository.Add(new Route() { OriginalPoint = pA, DestinationPoint = pH, Cost = 10, Time = 1 }, token);
            await repository.Add(new Route() { OriginalPoint = pA, DestinationPoint = pE, Cost = 30, Time = 5 }, token);
            await repository.Add(new Route() { OriginalPoint = pC, DestinationPoint = pB, Cost = 12, Time = 1 }, token);
            await repository.Add(new Route() { OriginalPoint = pH, DestinationPoint = pE, Cost = 1, Time = 30 }, token);
            await repository.Add(new Route() { OriginalPoint = pE, DestinationPoint = pD, Cost = 5, Time = 3 }, token);
            await repository.Add(new Route() { OriginalPoint = pD, DestinationPoint = pF, Cost = 50, Time = 4 }, token);
            await repository.Add(new Route() { OriginalPoint = pF, DestinationPoint = pI, Cost = 50, Time = 45 }, token);
            await repository.Add(new Route() { OriginalPoint = pF, DestinationPoint = pG, Cost = 50, Time = 40 }, token);
            await repository.Add(new Route() { OriginalPoint = pG, DestinationPoint = pB, Cost = 73, Time = 64 }, token);
            await repository.Add(new Route() { OriginalPoint = pI, DestinationPoint = pB, Cost = 73, Time = 64 }, token);

        }
        


    }
}
