using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRouteApp.API;
using MyRouteApp.Infrastructure.Persistence;
using MyRouteApp.Infrastructure.Persistence.Repository;

namespace MyRouteApp.Tests.RepositoryTest
{
    public class RepositoryBaseTest
    {
        public ServiceProvider Provider { get; private set; }
        public IConfigurationRoot Config { get; private set; }

        
        public virtual void Setup()
        {
            Config = new ConfigurationBuilder().AddInMemoryCollection().Build();
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("MyDbTest"));
            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            Provider = services.BuildServiceProvider();
        }
    }
}
