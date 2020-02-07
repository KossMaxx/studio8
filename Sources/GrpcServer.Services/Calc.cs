using System;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Calc.Server;
using Logic.Interfaces;
using Logic.Interfaces.Factories.CalcOperation;

namespace GrpcServer.Services
{
    public class CalcService : CalcOperation.CalcOperationBase
    {
        public CalcService(ITaskCreator taskCreator, IRulesVerificator rulesVerificator, ICalcOperationReplyFactory calcOperationReplyFactory)
        {
            TaskCreator = taskCreator;
            RulesVerificator = rulesVerificator;
            CalcOperationReplyFactory = calcOperationReplyFactory;
        }

        public override async Task<CalcOperationReply> Execute(CalcOperationRequest request, ServerCallContext context)
        {
            return await TaskCreator.Create(() => GetCalcOperationReply(request));
        }

        CalcOperationReply GetCalcOperationReply(CalcOperationRequest request)
        {
            try
            {
                RulesVerificator.VerifyServiceRules(request);
                return CalcOperationReplyFactory.Cube(request.Value);
            }
            catch (Exception exception)
            {
                return CalcOperationReplyFactory.Exception(exception.Message);
            }
        }

        ITaskCreator TaskCreator { get; }
        IRulesVerificator RulesVerificator { get; }
        ICalcOperationReplyFactory CalcOperationReplyFactory { get; }
    }
}
