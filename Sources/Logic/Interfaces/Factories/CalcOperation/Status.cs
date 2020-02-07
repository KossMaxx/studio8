using GrpcService;
using GrpcService.Calc.Server;

namespace Logic.Interfaces.Factories.CalcOperation
{
    public interface ICalcOperationStatusFactory
    {
        CalcOperationStatus Create(int code, string message);
        CalcOperationStatus Ok();
        CalcOperationStatus Exception(string message);
    }
}
