using GrpcClient.Interfaces;

namespace GrpcClient
{
    public class PathToSettings : IPathToSettings
    {
        public PathToSettings(string pathToSettingsFile)
        {
            PathToSettingsFile = pathToSettingsFile;
        }

        public string GetPath() => PathToSettingsFile;

        string PathToSettingsFile { get; }
    }
}
