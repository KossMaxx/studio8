using Logic.Interfaces;
using Project.Kernel;
using Unity;

namespace Logic.TypeFabrics
{
    public class ServiceTypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ITaskCreator, TaskCreator>();
        }
    }
}
