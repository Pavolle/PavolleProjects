using log4net;
using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.LogServer.ViewModels.Response;
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

namespace Pavolle.BES.LogServer.Business.Manager
{
    public class LogServerStatusManager : Singleton<LogServerStatusManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(LogServerStatusManager));
        private LogServerStatusManager() { }

        bool _elastichSearchStatus = false;
        bool _rabbitMQStatus=false;
        bool _serverStatus = false;
        bool _settingServerConnectionStatus=false;

        public LogServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            return new LogServerStatusResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version=WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate=WebAppInfoManager.Instance.GetReleaseDate(),
                ElasticSearchStatus = _elastichSearchStatus,
                ElasticSearchStatusString = _elastichSearchStatus ? "Ready" : "Not Ready",
                RabbitMQStatus = _rabbitMQStatus,
                RabbitMQStatusString = _rabbitMQStatus ? "Ready" : "Not Ready",
                ServerStatus = _serverStatus,
                ServerStatusString = _serverStatus ? "Ready" : "Not Ready",
                SettingServerConnectionStatus = _settingServerConnectionStatus,
                SettingServerConnectionStatusString = _settingServerConnectionStatus ? "Connected" : "Not Connected"
            };
        }

        public void SetRabbitMQStatus(bool status)
        {
            _rabbitMQStatus = status;
        }

        public void SetServerStatus(bool status)
        {
            _serverStatus = status;
        }

        public void SetElastichSearchStatus(bool status)
        {
            _elastichSearchStatus = status;
        }

        public void SetSettingServerConnectionStatus(bool status)
        {
            _settingServerConnectionStatus = status;
        }

        public LogServerSettingsResponse GetServerSettings(IntegrationAppRequestBase request)
        {
            return new LogServerSettingsResponse
            {
                Language= SettingServiceManager.Instance.GetDefaultLanguage(),
                SystemLanguage = SettingServiceManager.Instance.GetSystemLanguage(),
                SettingServerBaseUrl = SettingServiceManager.Instance.GetServerUrl(),
                TranslateServerBaseUrl = SettingServiceManager.Instance.GetSetting(ESettingType.TranslateServerBaseUrl),
                LogServerRabbitMQUsername = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQUsername),
                LogServerRabbitMQPassword = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQPassword),
                LogServerRabbitMQHostname = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQHostname),
                LogServerRabbitMQVHost = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQVHost),
                LogServerRabbitMQPort = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerRabbitMQPort),
                LogServerExchangeName = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerExchangeName),
                LogServerLogQueueKey = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerLogQueueKey),
                LogServerLogRoutingKey = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerLogRoutingKey),
                LogServerLogErrorQueueKey = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerLogErrorQueueKey),
                LogServerLogErrorRoutingKey = SettingServiceManager.Instance.GetSetting(ESettingType.LogServerLogErrorRoutingKey)
            };
        }
    }
}
