using System;
using GrpcService.Calc.Client;
using Logic.Interfaces.Factories.CalcOperation;

namespace Logic.Factories.CalcOperation
{
    public class CalcOperationRequestFactory: ICalcOperationRequestFactory
    {
        public CalcOperationRequest Create(int value, string operation)
        {
            Enum.TryParse(operation, true, out CalcOperationType convertOperationResult);
            return new CalcOperationRequest {Operation = convertOperationResult, Value = value};
        }
    }
}
