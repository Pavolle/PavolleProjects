using Pavolle.BES.MailServer.ViewModels.Response;
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

namespace Pavolle.BES.MailServer.Business.Manager
{
    public class MailServerStatusManager : Singleton<MailServerStatusManager>
    {
        private MailServerStatusManager() { }

        public MailServerSettingsResponse GetServerSettings(IntegrationAppRequestBase request)
        {
            return new MailServerSettingsResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version = WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate = WebAppInfoManager.Instance.GetReleaseDate(),
                DbStatus = _dbStatus,
                DbStatusString = _dbStatus ? "Connected" : "Connection Error",
                RabbitMQStatus = _rabbitMQStatus,
                RabbitMQStatusString = _rabbitMQStatus ? "Ready" : "Not Ready",
                ServerStatus = _serverStatus && _rabbitMQStatus && _dbStatus,
                ServerStatusString = _serverStatus && _rabbitMQStatus && _dbStatus ? "Ready" : "Not Ready",
                SettingServerConnectionStatus = _settingServerConnectionStatus,
                SettingServerConnectionStatusString = _settingServerConnectionStatus ? "Connected" : "Not Connected",
                SettingsReloadTime = SettingServiceManager.Instance.GetSettingsReloadTime()
            };
        }

        public MailServereStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            return new MailServereStatusResponse
            {
                Language = SettingServiceManager.Instance.GetDefaultLanguage(),
                SystemLanguage = SettingServiceManager.Instance.GetSystemLanguage(),
                SettingServerBaseUrl = SettingServiceManager.Instance.GetServerUrl(),
                TranslateServerBaseUrl = SettingServiceManager.Instance.GetSetting(ESettingType.TranslateServerBaseUrl),
                MailServerRabbitMQUsername = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQUsername),
                MailServerRabbitMQPassword = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQPassword),
                MailServerRabbitMQHostname = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQHostname),
                MailServerRabbitMQVHost = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQVHost),
                MailServerRabbitMQPort = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerRabbitMQPort),
                MailServerExchangeName = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerExchangeName),
                MailServerMailQueueKey = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerMailQueueKey),
                MailServerMailRoutingKey = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerMailRoutingKey),
                MailServerMailErrorQueueKey = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerMailErrorQueueKey),
                MailServerMailErrorRoutingKey = SettingServiceManager.Instance.GetSetting(ESettingType.MailServerMailErrorRoutingKey)
            };
        }

        bool _dbStatus;
        bool _serverStatus;
        bool _rabbitMQStatus;
        bool _settingServerConnectionStatus;

        public void SetDbStatus(bool dbStatus)
        {
            _dbStatus = dbStatus;
        }

        public void SetRabbitMQStatus(bool rabbitMQStatus)
        {
            _rabbitMQStatus = rabbitMQStatus;
        }

        public void SetServerStatus(bool serverStatus)
        {
            _serverStatus = serverStatus;
        }

        public void SetSettingServerConnectionStatus(bool settingServerStatus)
        {
            _settingServerConnectionStatus = settingServerStatus;
        }
    }
}
