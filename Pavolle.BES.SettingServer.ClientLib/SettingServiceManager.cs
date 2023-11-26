using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.Common.Utils;
using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;

namespace Pavolle.BES.SettingServer.ClientLib
{
    public class SettingServiceManager : Singleton<SettingServiceManager>
    {
        public string _serviceUrl ="";
        List<SettingViewData> _settingList;
        private SettingServiceManager() { }

        public void Initialize(string servciceUrl, string appCode, string appId)
        {
            _serviceUrl = servciceUrl;
            ServiceHelperManager.Instance.Initialize(appCode, appId);

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

        private void GetSettingsList()
        {
            if (string.IsNullOrEmpty(_serviceUrl))
            {
                return;
            }
            else
            {
                var response= ServiceHelperManager.Instance.Get<SettingListResponse>(_serviceUrl, SettingServerConsts.SettingsUrlConst.Route + "/" + SettingServerConsts.SettingsUrlConst.ListRoutePrefix);
                if(response == null)
                {
                    _settingList = new List<SettingViewData>();
                }
                else
                {
                    _settingList = response.DataList;
                }
            }
        }

        public string GetSetting(ESettingType settingType)
        {
            return _settingList.FirstOrDefault(t => t.SettingType == settingType).Value;
        }

        public ELanguage GetDefaultLanguage()
        {
            var data = _settingList.FirstOrDefault(t => t.SettingType == ESettingType.DefaultLanguage);
            if (data == null)
                return ELanguage.English;
            return (ELanguage)Convert.ToInt32(data.Value);
        }

        public ELanguage GetSystemLanguage()
        {
            var data = _settingList.FirstOrDefault(t => t.SettingType == ESettingType.SystemLanguage);
            if (data == null)
                return ELanguage.English;
            return (ELanguage)Convert.ToInt32(data.Value);
        }

        public string GetServerUrl()
        {
            return _serviceUrl;
        }
    }
}