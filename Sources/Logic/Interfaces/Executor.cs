using GrpcService.Calc.Client;

namespace Logic.Interfaces
{
    public interface ICalcOperationExecutor
    {
        CalcOperationReply Execute(int value, string operation);
    }
}
