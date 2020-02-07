using GrpcServer.Services.Interfaces;
using Project.Kernel;
using Unity;

namespace GrpcServer.Services
{
    public class TypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IServicesRegistrator, ServicesRegistrator>();
        }
    }
}
