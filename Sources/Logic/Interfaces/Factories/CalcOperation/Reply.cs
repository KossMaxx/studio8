using GrpcService.Calc.Server;

namespace Logic.Interfaces.Factories.CalcOperation
{
    public interface ICalcOperationReplyFactory
    {
        CalcOperationReply Square(int value);
        CalcOperationReply Cube(int value);
        CalcOperationReply Exception(string message);
        GrpcService.Calc.Client.CalcOperationReply Convert(CalcOperationReply serverReply);
    }
}
