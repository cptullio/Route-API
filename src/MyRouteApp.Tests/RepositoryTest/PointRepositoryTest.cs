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
    public class PointRepositoryTest : RepositoryBaseTest
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
            IPointRepository repository = Provider.GetService<IPointRepository>();
            var points = await repository.GetAll(token);
            foreach (var item in points)
            {
                await repository.Delete(item.Id, token);
            }
        }

        [TestMethod]
        public async Task CreatePointTest()
        {
            var token = new System.Threading.CancellationToken();
            IPointRepository repository = Provider.GetService<IPointRepository>();
            var point = await repository.Add(new Infrastructure.Persistence.DTO.Point() { Name = "A" }, token);
            Assert.IsNotNull(point);
        }

        [TestMethod]
        public async Task GetPointsTest()
        {
            var token = new System.Threading.CancellationToken();
            IPointRepository repository = Provider.GetService<IPointRepository>();
            await repository.Add(new Infrastructure.Persistence.DTO.Point() { Name = "A" }, token);
            await repository.Add(new Infrastructure.Persistence.DTO.Point() { Name = "B" }, token);
            await repository.Add(new Infrastructure.Persistence.DTO.Point() { Name = "C" }, token);
            var points = await repository.GetAll(token);
            Assert.IsNotNull(points);
            Assert.AreEqual(3, points.Count());
        }

    }
}
