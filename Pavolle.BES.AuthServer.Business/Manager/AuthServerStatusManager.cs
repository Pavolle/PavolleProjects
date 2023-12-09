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
        bool _userLoaded = false;

        bool _loadPersoneStatus =false;
        bool _loadRolesStatus = false;
        bool _loadCommunicationInfo = false;

        private AuthServerStatusManager() { }

        public AuthServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            bool serverRealStatus = _settingServerConnectionStatus && _serverStatus && _dbStatus && _userLoaded && _loadPersoneStatus && _loadRolesStatus && _loadCommunicationInfo;
            return new AuthServerStatusResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version = WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate = WebAppInfoManager.Instance.GetReleaseDate(),
                DbStatus = _dbStatus,
                DbStatusString = _dbStatus ? "Connected" : "Connection Error",
                LoadUserStatus = _userLoaded,
                LoadUserStatusString = _userLoaded ? "Loaded" : "Connection Error",
                LoadPersonStatus = _loadPersoneStatus,
                LoadPersonStatusString = _loadPersoneStatus ? "Loaded" : "Connection Error",
                LoadRoleStatus = _loadRolesStatus,
                LoadRoleStatusString = _loadRolesStatus ? "Loaded" : "Connection Error",
                LoadCommunicationInfoStatus = _loadCommunicationInfo,
                LoadCommunicationInfoStatusString = _loadCommunicationInfo ? "Loaded" : "Connection Error",
                ServerStatus = serverRealStatus,
                ServerStatusString = serverRealStatus ? "Ready" : "Not Ready",
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
                DbConnectionString = SettingServiceManager.Instance.GetSetting(ESettingType.DbConnection) != null ? "Ok" : "Error!"
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

        public void SetUserLoaded(bool status)
        {
            _userLoaded = status;
        }
        public void SetPersonLoaded(bool status)
        {
            _loadPersoneStatus = status;
        }

        public void SetRolesLoaded(bool status)
        {
            _loadRolesStatus = status;
        }

        public void SetCommunicationInfoLoaded(bool status)
        {
            _loadCommunicationInfo = status;
        }
    }
}
