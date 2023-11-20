using DevExpress.Xpo;
using log4net;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.DbModels;
using Pavolle.BES.SettingServer.DbModels.Entities;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Business
{
    public class SetupManager : Singleton<SetupManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SetupManager));
        private SetupManager()
        {

        }

        public void Initialize()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var settings = session.Query<Setting>().ToList();

                var settingTypes = Enum.GetValues(typeof(ESettingType)).Cast<ESettingType>().ToList();

                foreach (var item in settingTypes)
                {
                    if (!settings.Any(t => t.SettingType == item))
                    {
                        switch (item)
                        {
                            case ESettingType.DbConnection:
                                break;
                            case ESettingType.LogServerUrl:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "https://localhost:7120",
                                }.Save();

                                _log.Info("LogServerUrl  value is https:localhost:1212");
                                break;
                            case ESettingType.LogServerRabbitMQUsername:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                }.Save();

                                _log.Info("LogServerRabbitMQUsername value is guest");
                                break;
                            case ESettingType.LogServerRabbitMQPassword:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                }.Save();

                                _log.Info("LogServerRabbitMQPassword value is guest");
                                break;
                            case ESettingType.LogServerRabbitMQVHost:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "/",
                                }.Save();

                                _log.Info("LogServerRabbitMQVHost value is \"/\"");
                                break;
                            case ESettingType.LogServerRabbitMQHostname:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "localhost",
                                }.Save();

                                _log.Info("LogServerRabbitMQHostname value is localhost");
                                break;
                            case ESettingType.LogServerRabbitMQPort:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "5672",
                                }.Save();

                                _log.Info("LogServerRabbitMQPort value is 5672");
                                break;

                            case ESettingType.LogServerExchangeName:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOG_SERVER",
                                }.Save();

                                _log.Info("LogServerExchangeName value is LOG_SERVER");
                                break;

                            case ESettingType.LogServerLogQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOGS",
                                }.Save();

                                _log.Info("LogServerLogQueueKey value is LOGS");
                                break;

                            case ESettingType.LogServerLogRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOGS",
                                }.Save();

                                _log.Info("LogServerLogRoutingKey value is LOGS");
                                break;

                            case ESettingType.LogServerLogErrorQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOG_ERRORS",
                                }.Save();

                                _log.Info("LogServerLogErrorQueueKey value is LOG_ERRORS");
                                break;

                            case ESettingType.LogServerLogErrorRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOG_ERRORS",
                                }.Save();

                                _log.Info("LogServerLogErrorRoutingKey value is LOG_ERRORS");
                                break;

                            case ESettingType.DYSBaseFilePath:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "C://pavolle//bes//dys",
                                }.Save();

                                _log.Info("DYSBaseFilePath value is C://pavolle//bes//dys");
                                break;

                            case ESettingType.TranslateServerBaseUrl:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "https://localhost:7118/",
                                }.Save();

                                _log.Info("TranslateServerBaseUrl value is https://localhost:7118/");
                                break;

                            case ESettingType.DefaultLanguage:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = ((int)ELanguage.English).ToString(),
                                }.Save();

                                _log.Info("DefaultLanguage value is English");
                                break;

                            case ESettingType.SystemLanguage:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = ((int)ELanguage.English).ToString(),
                                }.Save();

                                _log.Info("SystemLanguage value is English");
                                break;

                        }
                    }
                }
            }
        }
    }
}
