using log4net;
using Pavolle.BES.PasswordServer.ViewModels.Response;
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

namespace Pavolle.BES.PasswordServer.Business.Manager
{
    public class PasswordServerStatusManager : Singleton<PasswordServerStatusManager>
    {

        static readonly ILog _log = LogManager.GetLogger(typeof(PasswordServerStatusManager));
        private PasswordServerStatusManager() { }

        bool _dbStatus = false;
        bool _serverStatus = false;
        bool _settingServerConnectionStatus = false;

        public PasswordServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            return new PasswordServerStatusResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version = WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate = WebAppInfoManager.Instance.GetReleaseDate(),
                DbStatus = _dbStatus,
                DbStatusString = _dbStatus ? "Connected" : "Connection Error!",
                ServerStatus = _serverStatus && _settingServerConnectionStatus,
                ServerStatusString = _serverStatus && _settingServerConnectionStatus ? "Ready" : "Not Ready",
                SettingServerConnectionStatus = _settingServerConnectionStatus,
                SettingServerConnectionStatusString = _settingServerConnectionStatus ? "Connected" : "Not Connected",
                SettingsReloadTime = SettingServiceManager.Instance.GetSettingsReloadTime()
            };
        }

        public void SetServerStatus(bool status)
        {
            _serverStatus = status;
        }

        public void SetDbStatus(bool status)
        {
            _dbStatus = status;
        }

        public void SetSettingServerConnectionStatus(bool status)
        {
            _settingServerConnectionStatus = status;
        }

        public PaswordServerSettingsResponse GetServerSettings(IntegrationAppRequestBase request)
        {
            return new PaswordServerSettingsResponse
            {
                Language = SettingServiceManager.Instance.GetDefaultLanguage(),
                SystemLanguage = SettingServiceManager.Instance.GetSystemLanguage(),
                SettingServerBaseUrl = SettingServiceManager.Instance.GetServerUrl(),
                TranslateServerBaseUrl = SettingServiceManager.Instance.GetSetting(ESettingType.TranslateServerBaseUrl),
            };
        }
    }
}
