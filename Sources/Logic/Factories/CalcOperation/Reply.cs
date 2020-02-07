using GrpcService.Calc.Client;
using Logic.Interfaces;
using Logic.Interfaces.Factories.CalcOperation;
using CalcOperationReply = GrpcService.Calc.Server.CalcOperationReply;

namespace Logic.Factories.CalcOperation
{
    public class CalcOperationReplyFactory : ICalcOperationReplyFactory
    {
        public CalcOperationReplyFactory(ICalculator calculator, ICalcOperationStatusFactory calcOperationStatusFactory)
        {
            Calculator = calculator;
            CalcOperationStatusFactory = calcOperationStatusFactory;
        }

        public CalcOperationReply Square(int value)
        {
            return new CalcOperationReply
            {
                Result = Calculator.Square(value),
                Status = CalcOperationStatusFactory.Ok()
            };
        }

        public CalcOperationReply Cube(int value)
        {
            return new CalcOperationReply
            {
                Result = Calculator.Cube(value),
                Status = CalcOperationStatusFactory.Ok()
            };
        }

        public CalcOperationReply Exception(string message)
        {
            return new CalcOperationReply
            {
                Status = CalcOperationStatusFactory.Exception(message)
            };
        }

        public GrpcService.Calc.Client.CalcOperationReply Convert(CalcOperationReply serverReply)
        {
            return new GrpcService.Calc.Client.CalcOperationReply
            {
                Result = serverReply.Result,
                Status = new CalcOperationStatus
                {
                    Code = serverReply.Status.Code,
                    Message = serverReply.Status.Message
                }
            };
        }

        ICalculator Calculator { get; }
        ICalcOperationStatusFactory CalcOperationStatusFactory { get; }
    }
}
