using log4net;
using Pavolle.BES.AuthServer.ViewModels.Response;
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

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class AuthServerStatusManager : Singleton<AuthServerStatusManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(AuthServerStatusManager));
        bool _settingServerConnectionStatus = false;
        bool _serverStatus =false;
        bool _dbStatus = false;
        private AuthServerStatusManager() { }

        public AuthServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            return new AuthServerStatusResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version = WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate = WebAppInfoManager.Instance.GetReleaseDate(),
                DbStatus = _dbStatus,
                DbStatusString = _dbStatus ? "Connected" : "Connection Error",
                ServerStatus = _serverStatus && _dbStatus,
                ServerStatusString = _serverStatus && _dbStatus ? "Ready" : "Not Ready",
                SettingServerConnectionStatus = _settingServerConnectionStatus,
                SettingServerConnectionStatusString = _settingServerConnectionStatus ? "Connected" : "Not Connected",
                SettingsReloadTime = SettingServiceManager.Instance.GetSettingsReloadTime()
            };
        }

        public AuthServerSettingsResponse GetServerSettings(IntegrationAppRequestBase request)
        {
            return new AuthServerSettingsResponse
            {
                Language = SettingServiceManager.Instance.GetDefaultLanguage(),
                SystemLanguage = SettingServiceManager.Instance.GetSystemLanguage(),
                SettingServerBaseUrl = SettingServiceManager.Instance.GetServerUrl(),
                TranslateServerBaseUrl = SettingServiceManager.Instance.GetSetting(ESettingType.TranslateServerBaseUrl),
                DbConnectionString=SettingServiceManager.Instance.GetSetting(ESettingType.DbConnection)
            };
        }

        public void SetDbStatus(bool dbStatus)
        {
            _dbStatus = dbStatus;
        }

        public void SetServerStatus(bool status)
        {
            _serverStatus = status;
        }

        public void SetSettingServerConnectionStatus(bool status)
        {
            _settingServerConnectionStatus = status;
        }
    }
}
