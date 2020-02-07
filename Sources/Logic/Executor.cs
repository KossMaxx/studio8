using System;
using GrpcService.Calc.Client;
using Logic.Interfaces;
using Logic.Interfaces.Factories.CalcOperation;
using Project.Kernel;

namespace Logic
{
    public class CalcOperationExecutor : ICalcOperationExecutor
    {
        public CalcOperationExecutor(IWrapper<CalcOperation.CalcOperationClient> calcOperationClient,
            ICalcOperationRequestFactory calcOperationRequestFactory,
            ICalcOperationReplyFactory calcOperationReplyFactory, IRulesVerificator rulesVerificator)
        {
            CalcOperationClient = calcOperationClient;
            CalcOperationRequestFactory = calcOperationRequestFactory;
            CalcOperationReplyFactory = calcOperationReplyFactory;
            RulesVerificator = rulesVerificator;
        }

        public CalcOperationReply Execute(int value, string operation)
        {
            try
            {
                RulesVerificator.VerifyInputDataRules(value, operation);
                var request = CalcOperationRequestFactory.Create(value, operation);
                var result = CalcSquare(request);
                return result ?? CalcCube(request);
            }
            catch (Exception exception)
            {
                var exceptionReply = CalcOperationReplyFactory.Exception(exception.Message);
                return CalcOperationReplyFactory.Convert(exceptionReply);
            }
        }

        private CalcOperationReply CalcSquare(CalcOperationRequest request)
        {
            if (request.Value % 2 != 1 || request.Operation != CalcOperationType.Square) return null;
            var reply = CalcOperationReplyFactory.Square(request.Value);
            return CalcOperationReplyFactory.Convert(reply);
        }

        private CalcOperationReply CalcCube(CalcOperationRequest request)
        {
            if ((request.Value % 2 == 0 || request.Value >= 2 || request.Value <= 50) && request.Operation == CalcOperationType.Cube)
                return CalcOperationClient.Instance.Execute(request);
            throw new ArgumentOutOfRangeException($"Argument out of range: [value] - {request.Value}, [operation] - {request.Operation}");
        }

        IWrapper<CalcOperation.CalcOperationClient> CalcOperationClient { get; }
        ICalcOperationRequestFactory CalcOperationRequestFactory { get; set; } 
        ICalcOperationReplyFactory CalcOperationReplyFactory { get; }
        IRulesVerificator RulesVerificator { get; set; }
    }
}
