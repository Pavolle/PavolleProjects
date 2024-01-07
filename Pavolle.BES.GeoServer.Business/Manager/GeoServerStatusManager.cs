using log4net;
using Pavolle.BES.GeoServer.ViewModels.Response;
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

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class GeoServerStatusManager : Singleton<GeoServerStatusManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(GeoServerStatusManager));

        bool _dbStatus;
        bool _serverStatus;
        bool _settingServerConnectionStatus;
        private GeoServerStatusManager() { }

        public GeoServerSettingsResponse GetServerSettings(IntegrationAppRequestBase request)
        {
            return new GeoServerSettingsResponse
            {
                Language = SettingServiceManager.Instance.GetDefaultLanguage(),
                SystemLanguage = SettingServiceManager.Instance.GetSystemLanguage(),
                SettingServerBaseUrl = SettingServiceManager.Instance.GetServerUrl(),
                TranslateServerBaseUrl = SettingServiceManager.Instance.GetSetting(ESettingType.TranslateServerBaseUrl),
                DbConnectionString = SettingServiceManager.Instance.GetSetting(ESettingType.DbConnection) != null ? "Ok" : "Error!",
                CountryFlagBaseUrl = SettingServiceManager.Instance.GetSetting(ESettingType.GeolocationCountryFlagBaseUrl),
            };
        }

        public GeoServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            bool serverRealStatus = _settingServerConnectionStatus && _serverStatus && _dbStatus;
            return new GeoServerStatusResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version = WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate = WebAppInfoManager.Instance.GetReleaseDate(),
                DbStatus = _dbStatus,
                DbStatusString = _dbStatus ? "Connected" : "Connection Error",
                ServerStatus = serverRealStatus,
                ServerStatusString = serverRealStatus ? "Ready" : "Not Ready",
                SettingServerConnectionStatus = _settingServerConnectionStatus,
                SettingServerConnectionStatusString = _settingServerConnectionStatus ? "Connected" : "Not Connected",
                SettingsReloadTime = SettingServiceManager.Instance.GetSettingsReloadTime()
            };
        }

        public void SetDbStatus(bool dbConnection)
        {
            _dbStatus = dbConnection;
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
