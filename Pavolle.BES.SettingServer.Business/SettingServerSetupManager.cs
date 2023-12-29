using DevExpress.Xpo;
using log4net;
using Pavolle.BES.AppServer.Common.Enums;
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
    public class SettingServerSetupManager : Singleton<SettingServerSetupManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SettingServerSetupManager));
        private SettingServerSetupManager()
        {

        }

        public void Initialize()
        {
            using (Session session = SettingServerXpoManager.Instance.GetNewSession())
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
                                    Category=ESettingCategory.LogServer,
                                    IsCriticalData =false
                                }.Save();

                                _log.Info("LogServerUrl  value is https://localhost:7120");
                                break;
                            case ESettingType.LogServerRabbitMQUsername:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerRabbitMQUsername value is guest");
                                break;
                            case ESettingType.LogServerRabbitMQPassword:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = true
                                }.Save();

                                _log.Info("LogServerRabbitMQPassword value is guest");
                                break;
                            case ESettingType.LogServerRabbitMQVHost:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "/",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerRabbitMQVHost value is \"/\"");
                                break;
                            case ESettingType.LogServerRabbitMQHostname:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "localhost",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerRabbitMQHostname value is localhost");
                                break;
                            case ESettingType.LogServerRabbitMQPort:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "5672",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerRabbitMQPort value is 5672");
                                break;

                            case ESettingType.LogServerExchangeName:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOG_SERVER",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerExchangeName value is LOG_SERVER");
                                break;

                            case ESettingType.LogServerLogQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOGS",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerLogQueueKey value is LOGS");
                                break;

                            case ESettingType.LogServerLogRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOGS",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerLogRoutingKey value is LOGS");
                                break;

                            case ESettingType.LogServerLogErrorQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOG_ERRORS",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerLogErrorQueueKey value is LOG_ERRORS");
                                break;

                            case ESettingType.LogServerLogErrorRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "LOG_ERRORS",
                                    Category = ESettingCategory.LogServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("LogServerLogErrorRoutingKey value is LOG_ERRORS");
                                break;

                            case ESettingType.DYSBaseFilePath:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "C://pavolle//bes//dys",
                                    Category = ESettingCategory.DYS,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("DYSBaseFilePath value is C://pavolle//bes//dys");
                                break;

                            case ESettingType.TranslateServerBaseUrl:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "https://localhost:7118",
                                    Category = ESettingCategory.TranslateServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("TranslateServerBaseUrl value is https://localhost:7118");
                                break;

                            case ESettingType.DefaultLanguage:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = ((int)ELanguage.English).ToString(),
                                    Category = ESettingCategory.General,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("DefaultLanguage value is English");
                                break;

                            case ESettingType.SystemLanguage:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = ((int)ELanguage.English).ToString(),
                                    Category = ESettingCategory.General,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SystemLanguage value is English");
                                break;


                            case ESettingType.MailServerUrl:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "https://localhost:7065",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerUrl  value is https://localhost:7065");
                                break;
                            case ESettingType.MailServerRabbitMQUsername:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerRabbitMQUsername value is guest");
                                break;
                            case ESettingType.MailServerRabbitMQPassword:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = true
                                }.Save();

                                _log.Info("MailServerRabbitMQPassword value is guest");
                                break;
                            case ESettingType.MailServerRabbitMQVHost:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "/",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerRabbitMQVHost value is \"/\"");
                                break;
                            case ESettingType.MailServerRabbitMQHostname:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "localhost",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerRabbitMQHostname value is localhost");
                                break;
                            case ESettingType.MailServerRabbitMQPort:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "5672",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerRabbitMQPort value is 5672");
                                break;

                            case ESettingType.MailServerExchangeName:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "MAIL_SERVER",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerExchangeName value is MAIL_SERVER");
                                break;

                            case ESettingType.MailServerMailQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "MAILS",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerMailQueueKey value is MAILS");
                                break;

                            case ESettingType.MailServerMailRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "MAILS",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerMailRoutingKey value is MAILS");
                                break;

                            case ESettingType.MailServerMailErrorQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "MAIL_ERRORS",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerMailErrorQueueKey value is MAIL_ERRORS");
                                break;

                            case ESettingType.MailServerMailErrorRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "MAIL_ERRORS",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerMailErrorRoutingKey value is MAIL_ERRORS");
                                break;

                            case ESettingType.MailServerPavolleHostname:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "mail.pavolle.com",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerPavolleHostname value is mail.pavolle.com");
                                break;

                            case ESettingType.MailServerPavolleUsername:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "security@pavolle.com",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerPavolleUsername value is security@pavolle.com");
                                break;

                            case ESettingType.MailServerPavollePassword:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "m2A@g6@h-90@SC",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = true
                                }.Save();

                                _log.Info("MailServerPavollePassword value is ******");
                                break;

                            case ESettingType.MailServerPavollePort:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "587",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerPavollePort value is 587");
                                break;

                            case ESettingType.MailServerCurrentIntegration:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "1",
                                    Category = ESettingCategory.MailServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("MailServerCurrentIntegration value is 'Pavolle Mail Server'");
                                break;




                            case ESettingType.SMSServerUrl:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "https://localhost:7231",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerUrl  value is https://localhost:7231");
                                break;
                            case ESettingType.SMSServerRabbitMQUsername:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerRabbitMQUsername value is guest");
                                break;
                            case ESettingType.SMSServerRabbitMQPassword:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = true
                                }.Save();

                                _log.Info("SMSServerRabbitMQPassword value is guest");
                                break;
                            case ESettingType.SMSServerRabbitMQVHost:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "/",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerRabbitMQVHost value is \"/\"");
                                break;
                            case ESettingType.SMSServerRabbitMQHostname:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "localhost",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerRabbitMQHostname value is localhost");
                                break;
                            case ESettingType.SMSServerRabbitMQPort:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "5672",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerRabbitMQPort value is 5672");
                                break;

                            case ESettingType.SMSServerExchangeName:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "SMS_SERVER",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerExchangeName value is SMS_SERVER");
                                break;

                            case ESettingType.SMSServerSMSQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "SMS",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerSMSQueueKey value is SMS");
                                break;

                            case ESettingType.SMSServerSMSRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "SMS",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerSMSRoutingKey value is SMS");
                                break;

                            case ESettingType.SMSServerSMSErrorQueueKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "SMS_ERRORS",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerSMSErrorQueueKey value is SMS_ERRORS");
                                break;

                            case ESettingType.SMSServerSMSErrorRoutingKey:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "SMS_ERRORS",
                                    Category = ESettingCategory.SMSServer,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SMSServerSMSErrorRoutingKey value is SMS_ERRORS");
                                break;

                            case ESettingType.SurrveyServerlURL:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "https://localhost:44442",
                                    Category = ESettingCategory.Surrvey,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SurrveyServerlURL value is https://localhost:44442/");
                                break;

                            case ESettingType.SurrveyServerImageBaseFilePath:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "C://pavolle//surrvey//images//",
                                    Category = ESettingCategory.Surrvey,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("SurrveyServerImageBaseFilePath value is C://pavolle//surrvey//images//");
                                break;

                            case ESettingType.AuthServerUrl:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "https://localhost:7157",
                                    Category = ESettingCategory.Surrvey,
                                    IsCriticalData = false
                                }.Save();

                                _log.Info("AuthServerUrl value is https://localhost:7157");
                                break;

                        }
                    }
                }
            }
        }
    }
}
