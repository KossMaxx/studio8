using Logic.Factories.CalcOperation;
using Logic.Interfaces;
using Logic.Interfaces.Factories.CalcOperation;
using Project.Kernel;
using Unity;

namespace Logic.TypeFabrics
{
    public class ClientTypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICalcOperationRequestFactory, CalcOperationRequestFactory>();
            container.RegisterType<ICalcOperationExecutor, CalcOperationExecutor>();
        }
    }
}
