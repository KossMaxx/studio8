using System;
using GrpcServer.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace GrpcServer.Services
{
    public class ServicesRegistrator: IServicesRegistrator
    {
        public void Register(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<CalcService>();
        }
    }
}
