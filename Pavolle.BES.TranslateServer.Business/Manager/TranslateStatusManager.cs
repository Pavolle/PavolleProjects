using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Manager;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.Business.Manager
{
    public class TranslateStatusManager : Singleton<TranslateStatusManager>
    {

        bool _dbStatus = false;
        bool _settingServerStatus = false;
        bool _serverStatus = false;
        private TranslateStatusManager() { }

        public TranslateServerSettingsResponse GetServerSettings(IntegrationAppRequestBase request)
        {
            return new TranslateServerSettingsResponse
            {
                Language = SettingServiceManager.Instance.GetDefaultLanguage(),
                SystemLanguage = SettingServiceManager.Instance.GetSystemLanguage(),
                SettingServerBaseUrl = SettingServiceManager.Instance.GetServerUrl(),
                DbConnectionString = SettingServiceManager.Instance.GetSetting(ESettingType.DbConnection) != null ? "Ok" : "Error!"
            };
        }

        public TranslateServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            bool serverStatus = _serverStatus && _settingServerStatus && _dbStatus;
            return new TranslateServerStatusResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version = WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate = WebAppInfoManager.Instance.GetReleaseDate(),
                ServerStatus = serverStatus,
                ServerStatusString = serverStatus ? "Ready" : "Not Ready",
                DbStatus = _dbStatus,
                DbStatusString = _dbStatus ? "Connected" : "Connection Error!",
                SettingServerConnectionStatus = _settingServerStatus,
                SettingServerConnectionStatusString = _settingServerStatus ? "Connected" : "Not Connected",
                SettingsReloadTime = SettingServiceManager.Instance.GetSettingsReloadTime()
            };
        }

        public void SetDbStatus(bool dbStatus)
        {
            _dbStatus = dbStatus;
        }

        public void SetSettingServerConnectionStatus(bool settingServerStatus)
        {
            _settingServerStatus = settingServerStatus;
        }
    }
}
