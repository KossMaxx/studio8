using AutoFixture.Xunit2;
using GrpcService.Calc.Client;
using Logic.Factories.CalcOperation;
using Logic.Interfaces;
using Logic.Interfaces.Factories.CalcOperation;
using Moq;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace Logic.Tests
{
    public class ExecutorTests
    {
        [Theory]
        [MoqInlineAutoData(21, "square")]
        public void LocalSquareFunctionAvaibleTest(int value, string operation,
            GrpcService.Calc.Server.CalcOperationReply actualServerReply, CalcOperationReply actualClientReply,
            [Frozen] Mock<ICalcOperationRequestFactory> calcOperationRequestFactory,
            [Frozen] Mock<ICalcOperationReplyFactory> calcOperationReplyFactory,
            [Frozen] Mock<IRulesVerificator> rulesVerificator,
            CalcOperationRequestFactory realCalcOperationRequestFactory, CalcOperationExecutor executor)
        {
            //arrange
            var request = realCalcOperationRequestFactory.Create(value, operation);
            calcOperationRequestFactory.Setup(service => service.Create(value, operation)).Returns(request);
            calcOperationReplyFactory.Setup(service => service.Square(value)).Returns(actualServerReply);
            calcOperationReplyFactory.Setup(service => service.Convert(actualServerReply)).Returns(actualClientReply);

            //act
            var expected = executor.Execute(value, operation);

            //assert
            rulesVerificator.Verify(service=>service.VerifyInputDataRules(value, operation), Times.AtLeastOnce);
            calcOperationRequestFactory.Verify(service => service.Create(value, operation), Times.AtLeastOnce);
            calcOperationReplyFactory.Verify(service => service.Square(value), Times.AtLeastOnce);
            calcOperationReplyFactory.Verify(service => service.Convert(actualServerReply), Times.AtLeastOnce);

            Assert.IsType<CalcOperationReply>(expected);
            Assert.Equal(expected.Result, actualClientReply.Result);
            Assert.Equal(expected.Status.Code, actualClientReply.Status.Code);
            Assert.Equal(expected.Status.Message, actualClientReply.Status.Message);
        }
    }
}