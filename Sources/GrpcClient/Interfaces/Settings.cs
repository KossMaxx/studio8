using System;

namespace GrpcClient.Interfaces
{
    public interface ISettings
    {
        Uri GrpcServer { get; }
    }
}
