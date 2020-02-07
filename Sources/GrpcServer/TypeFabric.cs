using Logic.Interfaces;
using Logic.TypeFabrics;
using Project.Kernel;
using Unity;

namespace GrpcServer
{
    public class TypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            BaseTypeFabric.RegisterTypes<SharedTypeFabric>(container);
            BaseTypeFabric.RegisterTypes<ServiceTypeFabric>(container);
            BaseTypeFabric.RegisterTypes<GrpcServer.Services.TypeFabric>(container);
            container.RegisterType<IStartup, Startup>();
        }
    }
}
