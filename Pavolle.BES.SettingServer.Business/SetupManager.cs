using DevExpress.Xpo;
using log4net;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.DbModels;
using Pavolle.BES.SettingServer.DbModels.Entities;
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
                                    Value = "https:localhost:1212",
                                }.Save();

                                _log.Info("LogServerUrl değeri https:localhost:1212 olarak ayarlandı.");
                                break;
                            case ESettingType.LogServerRabbitMQUsername:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                }.Save();

                                _log.Info("LogServerRabbitMQUsername değeri guest olarak ayarlandı.");
                                break;
                            case ESettingType.LogServerRabbitMQPassword:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                }.Save();

                                _log.Info("LogServerRabbitMQPassword değeri guest olarak ayarlandı.");
                                break;
                            case ESettingType.LogServerRabbitMQVHost:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "/",
                                }.Save();

                                _log.Info("LogServerRabbitMQVHost değeri \"/\" olarak ayarlandı.");
                                break;
                            case ESettingType.LogServerRabbitMQHostname:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "localhost",
                                }.Save();

                                _log.Info("LogServerRabbitMQHostname değeri localhost olarak ayarlandı.");
                                break;
                            case ESettingType.LogServerRabbitMQPort:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "5672",
                                }.Save();

                                _log.Info("LogServerRabbitMQPort değeri 5672 olarak ayarlandı.");
                                break;

                            case ESettingType.LogServerExchangeName:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "logserver",
                                }.Save();

                                _log.Info("LogServerExchangeName değeri logserver olarak ayarlandı.");
                                break;

                            case ESettingType.LogServerLogQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOGS",
                                }.Save();

                                _log.Info("LogServerLogQueueKey değeri LOGS olarak ayarlandı.");
                                break;

                            case ESettingType.LogServerLogRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOGS",
                                }.Save();

                                _log.Info("LogServerLogRoutingKey değeri LOGS olarak ayarlandı.");
                                break;

                            case ESettingType.LogServerLogErrorQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOG_ERRORS",
                                }.Save();

                                _log.Info("LogServerLogErrorQueueKey değeri LOG_ERRORS olarak ayarlandı.");
                                break;

                            case ESettingType.LogServerLogErrorRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOG_ERRORS",
                                }.Save();

                                _log.Info("LogServerLogErrorRoutingKey değeri LOG_ERRORS olarak ayarlandı.");
                                break;

                        }
                    }
                }
            }
        }
    }
}
