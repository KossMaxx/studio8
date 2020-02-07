using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClient.Interfaces
{
    public interface ISettingsFactory
    {
        ISettings GetSettings();
    }
}
