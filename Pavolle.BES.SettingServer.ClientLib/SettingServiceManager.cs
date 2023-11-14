using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.Core.Utils;

namespace Pavolle.BES.SettingServer.ClientLib
{
    public class SettingServiceManager : Singleton<SettingServiceManager>
    {
        public string _serviceUrl ="";
        private SettingServiceManager() { }

        public SettingsServerStatusResponse GetServerStatus()
        {
            if(string.IsNullOrEmpty(_serviceUrl))
            {
                return new SettingsServerStatusResponse
                {
                    ErrorMessage = "Setting Service is not initialized!"
                };
            }
            else
            {
                return new SettingsServerStatusResponse();
            }
        }

    }
}