using Logic.Factories.CalcOperation;
using Logic.Interfaces;
using Logic.Interfaces.Factories.CalcOperation;
using Project.Kernel;
using Unity;

namespace Logic.TypeFabrics
{
    public class SharedTypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRulesVerificator, RulesVerificator>();
            container.RegisterType<ICalculator, Calculator>();
            container.RegisterType<ICalcOperationStatusFactory, CalcOperationStatusFactory>();
            container.RegisterType<ICalcOperationReplyFactory, CalcOperationReplyFactory>();
        }
    }
}
