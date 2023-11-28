using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.Common.Utils;
using Pavolle.BES.SettingServer.ViewModels.Request;
using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;

namespace Pavolle.BES.SettingServer.ClientLib
{
    public class SettingServiceManager : Singleton<SettingServiceManager>
    {
        public string _serviceUrl ="";
        List<SettingViewData> _settingList;
        DateTime _lastLoadTime = DateTime.Now;
        private SettingServiceManager() { }

        public void Initialize(string servciceUrl, string appCode, string appId)
        {
            _serviceUrl = servciceUrl;
            ServiceHelperManager.Instance.Initialize(appCode, appId);
            ReloadAllSettings();
        }

        public void ReloadAllSettings()
        {
            GetSettingsList();
            _lastLoadTime = DateTime.Now;
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
                return ServiceHelperManager.Instance.Get<SettingsServerStatusResponse>(_serviceUrl, SettingServerConsts.ServerStatusUrlConst.BaseRoute + "/" + SettingServerConsts.ServerStatusUrlConst.ServerDetailRoutePrefix);
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
                var response= ServiceHelperManager.Instance.Get<SettingListResponse>(_serviceUrl, SettingServerConsts.SettingsUrlConst.BaseRoute + "/" + SettingServerConsts.SettingsUrlConst.ListRoutePrefix);
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

        public ResponseBase UpdateSetting(ESettingType settingType, string value)
        {
            if (string.IsNullOrEmpty(_serviceUrl))
            {
                return new ResponseBase { StatusCode = 500, ErrorMessage = "Service Not Initialized!" };
            }


            var response = ServiceHelperManager.Instance.Post<SettingListResponse>(_serviceUrl, SettingServerConsts.SettingsUrlConst.BaseRoute + "/" + SettingServerConsts.SettingsUrlConst.EditRoutePrefix.Replace("{setting_type}", settingType.ToString()), new SettingRequest
            {
                Value = value
            });
            return response;
        }

        public ResponseBase DetailSetting(ESettingType settingType)
        {
            if (string.IsNullOrEmpty(_serviceUrl))
            {
                return new ResponseBase { StatusCode = 500, ErrorMessage = "Service Not Initialized!" };
            }
            var response = ServiceHelperManager.Instance.Get<SettingListResponse>(_serviceUrl, SettingServerConsts.SettingsUrlConst.BaseRoute + "/" + SettingServerConsts.SettingsUrlConst.DetailRoutePrefix.Replace("{setting_type}", settingType.ToString()));
            return response;
        }

        public DateTime GetSettingsReloadTime()
        {
            return _lastLoadTime;
        }
    }
}