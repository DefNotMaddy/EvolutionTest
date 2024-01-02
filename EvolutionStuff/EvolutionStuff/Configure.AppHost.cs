using EvolutionStuff.ServiceInterface;
using EvolutionStuff.ServiceInterface.Users;
using EvolutionStuff.ServiceModel.Models.DbModel;
using Funq;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Logging;

[assembly: HostingStartup(typeof(AppHost))]

namespace EvolutionStuff
{
    public class AppHost : AppHostBase, IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureServices(services =>
            {
            });

        public AppHost() : base("EvolutionStuff", typeof(EvolutionTestService).Assembly) { }

        public override void Configure(Container container)
        {
            string connStr = Environment.GetEnvironmentVariable("DbConnectionString") ?? throw new ArgumentNullException();
            string baseUri = Environment.GetEnvironmentVariable("BaseUri") ?? throw new ArgumentNullException();
            var dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connStr)
                .Options;
            container.Register<ILog>(c => LogManager.GetLogger(typeof(Service)));
            container.Register(c => new DatabaseContextFactory(dbContextOptions));
            container.Register<IUserRepository>(c => new UserRepository(c.Resolve<DatabaseContextFactory>().Create(), c.Resolve<ILog>()));
            container.Register<string>(baseUri);
        }
    }
}
