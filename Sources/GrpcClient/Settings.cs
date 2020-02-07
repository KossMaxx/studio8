using System;
using GrpcClient.Interfaces;

namespace GrpcClient
{
    public class Settings: ISettings
    {
        public Settings(Uri grpcServer)
        {
            GrpcServer = grpcServer;
        }

        public Uri GrpcServer { get; }
    }
}
