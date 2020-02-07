using GrpcService;
using GrpcService.Calc.Server;
using Logic.Interfaces.Factories.CalcOperation;

namespace Logic.Factories.CalcOperation
{
    public class CalcOperationStatusFactory: ICalcOperationStatusFactory
    {
        public CalcOperationStatus Create(int code, string message)
        {
            return new CalcOperationStatus {Code = code, Message = message};
        }

        public CalcOperationStatus Ok()
        {
            return Create(200, "Ok");
        }

        public CalcOperationStatus Exception(string message)
        {
            return Create(500, message);
        }
    }
}
