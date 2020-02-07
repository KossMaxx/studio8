using System.IO;
using GrpcClient.Interfaces;
using Newtonsoft.Json;

namespace GrpcClient
{
    public class SettingsFactory: ISettingsFactory
    {
        public SettingsFactory(IPathToSettings pathToSettings)
        {
            PathToSettings = pathToSettings;
        }

        public ISettings GetSettings()
        {
            var pathToSettings = PathToSettings.GetPath();
            var json = File.ReadAllText(pathToSettings);
            return JsonConvert.DeserializeObject<Settings>(json);
        }

        IPathToSettings PathToSettings { get; }
    }
}
