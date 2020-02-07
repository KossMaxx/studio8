using Grpc.Net.Client;
using GrpcClient.Interfaces;
using GrpcService.Calc.Client;
using Logic.Interfaces;
using Logic.TypeFabrics;
using Project.Kernel;
using Unity;
using Unity.Lifetime;

namespace GrpcClient
{
    public class TypeFabric:BaseTypeFabric
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            var pathToSettings = new PathToSettings("Settings.json");
            container.RegisterInstance<IPathToSettings>(pathToSettings);

            container.RegisterType<ISettingsFactory, SettingsFactory>();
            
            container.RegisterFactory<ISettings>(unityContainer =>
            {
                var factory = unityContainer.Resolve<ISettingsFactory>();
                return factory.GetSettings();
            }, new SingletonLifetimeManager());

            container.RegisterFactory<IWrapper<GrpcChannel>>(unityContainer =>
            {
                var settings = unityContainer.Resolve<ISettings>();
                var channel = GrpcChannel.ForAddress(settings.GrpcServer);
                return new Wrapper<GrpcChannel>(channel);
            });

            container.RegisterFactory<IWrapper<CalcOperation.CalcOperationClient>>(unityContainer =>
            {
                var channel = unityContainer.Resolve<IWrapper<GrpcChannel>>();
                var client = new CalcOperation.CalcOperationClient(channel.Instance);
                return new Wrapper<CalcOperation.CalcOperationClient>(client);
            });

            BaseTypeFabric.RegisterTypes<SharedTypeFabric>(container);
            BaseTypeFabric.RegisterTypes<ClientTypeFabric>(container);

            container.RegisterType<IStartup, Startup>();
        }
    }
}
