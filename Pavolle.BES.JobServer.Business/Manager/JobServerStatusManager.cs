using Pavolle.BES.JobServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Manager;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.Business.Manager
{
    public class JobServerStatusManager : Singleton<JobServerStatusManager>
    {
        private JobServerStatusManager() { }

        bool _dbStatus;
        bool _serverStatus;
        bool _settingServerConnectionStatus;

        public object GetServerSettings(IntegrationAppRequestBase request)
        {
            return new JobServerSettingsResponse
            {
                Language = SettingServiceManager.Instance.GetDefaultLanguage(),
                SystemLanguage = SettingServiceManager.Instance.GetSystemLanguage(),
                SettingServerBaseUrl = SettingServiceManager.Instance.GetServerUrl(),
                TranslateServerBaseUrl = SettingServiceManager.Instance.GetSetting(ESettingType.TranslateServerBaseUrl)
            };
        }

        public JobServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            return new JobServerStatusResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version = WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate = WebAppInfoManager.Instance.GetReleaseDate(),
                DbStatus = _dbStatus,
                DbStatusString = _dbStatus ? "Connected" : "Not Connected",
                ServerStatus = _serverStatus && _dbStatus && _settingServerConnectionStatus,
                ServerStatusString = _serverStatus && _dbStatus && _settingServerConnectionStatus ? "Ready" : "Not Ready",
                SettingServerConnectionStatus = _settingServerConnectionStatus,
                SettingServerConnectionStatusString = _settingServerConnectionStatus ? "Connected" : "Not Connected",
                SettingsReloadTime = SettingServiceManager.Instance.GetSettingsReloadTime()
            };
        }
        public void SetDbStatus(bool dbStatus)
        {
            _dbStatus = dbStatus;
        }

        public void SetServerStatus(bool serverStatus)
        {
            _serverStatus = serverStatus;
        }

        public void SetSettingServerConnectionStatus(bool settingServerConnectionStatus)
        {
            _settingServerConnectionStatus = settingServerConnectionStatus;
        }
    }
}
