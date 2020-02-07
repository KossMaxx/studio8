using System;
using Logic.Interfaces;

namespace GrpcClient
{
    public class Startup:IStartup
    {
        public Startup(ICalcOperationExecutor calcOperationExecutor)
        {
            CalcOperationExecutor = calcOperationExecutor;
        }

        public void Execute(string[] args)
        {
            Console.WriteLine("Wait start local grpc server. Press any key if local grpc server is started....");
            Console.ReadKey(true);

            Console.Write("Input value: ");
            var value = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input operation: ");
            var operation = Console.ReadLine();

            var result = CalcOperationExecutor.Execute(value, operation);
            
            Console.WriteLine($"Status Code: {result.Status.Code}, Message: {result.Status.Message}");
            Console.WriteLine($"Сalculation result: {result.Result}");
            Console.WriteLine("Press any key for exit...");
            Console.ReadKey(true);
        }

        ICalcOperationExecutor CalcOperationExecutor { get; }
    }
}
