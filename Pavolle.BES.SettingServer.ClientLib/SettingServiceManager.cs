using Pavolle.BES.SettingServer.Common.Utils;
using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.Core.Utils;
using System;

namespace Pavolle.BES.SettingServer.ClientLib
{
    public class SettingServiceManager : Singleton<SettingServiceManager>
    {
        public string _serviceUrl ="";
        private SettingServiceManager() { }

        public void Initialize(string servciceUrl)
        {
            _serviceUrl = servciceUrl;
        }

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
                return ServiceHelperManager.Instance.Get<SettingsServerStatusResponse>(_serviceUrl, SettingServerConsts.ServerStatusUrlConst.Route + "/" + SettingServerConsts.ServerStatusUrlConst.ServerDetailRoutePrefix);
            }
        }

        public SettingListResponse GetSettingsList()
        {
            if (string.IsNullOrEmpty(_serviceUrl))
            {
                return new SettingListResponse
                {
                    ErrorMessage = "Setting Service is not initialized!"
                };
            }
            else
            {
                return ServiceHelperManager.Instance.Get<SettingListResponse>(_serviceUrl, SettingServerConsts.SettingsUrlConst.Route + "/" + SettingServerConsts.SettingsUrlConst.ListRoutePrefix);
            }
        }

    }
}