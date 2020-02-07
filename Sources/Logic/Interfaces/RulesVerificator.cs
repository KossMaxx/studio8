using GrpcService.Calc.Server;

namespace Logic.Interfaces
{
    public interface IRulesVerificator
    {
        void VerifyInputDataRules(int value, string operation);
        void VerifyServiceRules(CalcOperationRequest request);
    }
}
