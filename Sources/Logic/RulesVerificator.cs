using System;
using GrpcService.Calc.Server;
using Logic.Interfaces;

namespace Logic
{
    public class RulesVerificator: IRulesVerificator
    {
        public void VerifyInputDataRules(int value, string operation)
        {
            if (string.Compare(operation, "square", StringComparison.OrdinalIgnoreCase) != 0 && string.Compare(operation, "cube", StringComparison.OrdinalIgnoreCase) != 0)
                throw new ArgumentOutOfRangeException($"Argument out of range: [operation] - {operation}");
            if (value >= 1 && value <= 100) return;
                throw new ArgumentOutOfRangeException($"Argument out of range: [value] - {value}");
        }

        public void VerifyServiceRules(CalcOperationRequest request)
        {
            if (request.Operation != CalcOperationType.Cube)
                throw new ArgumentException($"Inappropriate type of operation: [operation] - {request.Operation}");
            if (request.Value % 2 == 1 || request.Value < 2 || request.Value > 50)
                throw new ArgumentOutOfRangeException($"Argument out of range: [value] - {request.Value}");
        }
    }
}
