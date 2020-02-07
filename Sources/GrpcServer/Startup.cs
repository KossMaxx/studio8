using Unity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Unity.Microsoft.DependencyInjection;

namespace GrpcServer
{
    public class Startup: Logic.Interfaces.IStartup
    {
        public Startup(IUnityContainer container)
        {
            Container = container;
        }

        public void Execute(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();
            host.Run();
        }

        public IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseUnityServiceProvider(Container)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<InitWebHost>(); });

        IUnityContainer Container { get; }
    }
}
