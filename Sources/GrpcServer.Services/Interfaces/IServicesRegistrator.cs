using Microsoft.AspNetCore.Routing;

namespace GrpcServer.Services.Interfaces
{
    public interface IServicesRegistrator
    {
        void Register(IEndpointRouteBuilder endpoints);
    }
}
