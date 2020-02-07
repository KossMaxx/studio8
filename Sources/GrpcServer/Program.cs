using Logic.Interfaces;
using Project.Kernel;
using Unity;

namespace GrpcServer
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var container = UnityConfig.GetConfiguredContainer();
            BaseTypeFabric.RegisterTypes<TypeFabric>(container);
            var startup = container.Resolve<IStartup>();
            startup.Execute(args);
        }
    }
}
