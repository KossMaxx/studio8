using GrpcService.Calc.Client;

namespace Logic.Interfaces.Factories.CalcOperation
{
    public interface ICalcOperationRequestFactory
    {
        CalcOperationRequest Create(int value, string operation);
    }
}
