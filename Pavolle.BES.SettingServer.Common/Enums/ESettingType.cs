using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Common.Enums
{
    public enum ESettingType
    {
        #region General
        [Description("Db Connection")]
        DbConnection = 10000,

        [Description("Default Language")]
        DefaultLanguage=10001,

        [Description("System Language")]
        SystemLanguage=10002,
        #endregion

        #region Log Server
        [Description("Log Server Url")]
        LogServerUrl = 20001,

        [Description("Log Server - RabbitMQ Username")]
        LogServerRabbitMQUsername = 20002,

        [Description("Log Server - RabbitMQ Password")]
        LogServerRabbitMQPassword =20003,

        [Description("Log Server - RabbitMQ VHost")]
        LogServerRabbitMQVHost = 20004,

        [Description("Log Server - RabbitMQ Hostname")]
        LogServerRabbitMQHostname = 20005,

        [Description("Log Server - RabbitMQ Port")]
        LogServerRabbitMQPort = 20006,

        [Description("Log Server - Exchange Name")]
        LogServerExchangeName = 20007,

        [Description("Log Server - Log Queue Key")]
        LogServerLogQueueKey = 20008,

        [Description("Log Server - Log Routing Key")]
        LogServerLogRoutingKey = 20009,

        [Description("Log Server - Log Error Queue Key")]
        LogServerLogErrorQueueKey= 20010,

        [Description("Log Server - Log Error Routing Key")]
        LogServerLogErrorRoutingKey = 20011,
        #endregion

        #region DYS
        [Description("DYS - Base File Path")]
        DYSBaseFilePath = 30000,
        #endregion

        #region Translate Server
        [Description("Translate Server Base Url")]
        TranslateServerBaseUrl = 40000,
        #endregion

        #region Mail Server
        [Description("Mail Server URL")]
        MailServerUrl = 50000,

        [Description("Mail Server - RabbitMQ Username")]
        MailServerRabbitMQUsername = 50001,

        [Description("Mail Server - RabbitMQ Password")]
        MailServerRabbitMQPassword = 50002,

        [Description("Mail Server - RabbitMQ VHost")]
        MailServerRabbitMQVHost = 50003,

        [Description("Mail Server - RabbitMQ Hostname")]
        MailServerRabbitMQHostname = 50004,

        [Description("Mail Server - RabbitMQ Port")]
        MailServerRabbitMQPort = 50005,

        [Description("Mail Server - Exchange Name")]
        MailServerExchangeName = 50006,

        [Description("Mail Server - Mail Queue Key")]
        MailServerMailQueueKey = 50007,

        [Description("Mail Server - Mail Routing Key")]
        MailServerMailRoutingKey = 50008,

        [Description("Mail Server - Mail Error Queue Key")]
        MailServerMailErrorQueueKey = 50009,

        [Description("Mail Server - Mail Error Routing Key")]
        MailServerMailErrorRoutingKey= 50010,

        [Description("Mail Server - Pavolle Hostname")]
        MailServerPavolleHostname = 50011,

        [Description("Mail Server - Pavolle Username")]
        MailServerPavolleUsername = 50012,

        [Description("Mail Server - Pavolle Password")]
        MailServerPavollePassword = 50013,

        [Description("Mail Server - Pavolle Port")]
        MailServerPavollePort = 50014,

        [Description("Mail Server - Pavolle Port")]
        MailServerCurrentIntegration = 50015,
        #endregion

        #region SMS Server
        [Description("SMS Server URL")]
        SMSServerUrl = 60000,

        [Description("SMS Server - RabbitMQ Username")]
        SMSServerRabbitMQUsername = 60001,

        [Description("SMS Server - RabbitMQ Password")]
        SMSServerRabbitMQPassword = 60002,

        [Description("SMS Server - RabbitMQ VHost")]
        SMSServerRabbitMQVHost = 60003,

        [Description("SMS Server - RabbitMQ Hostname")]
        SMSServerRabbitMQHostname = 60004,

        [Description("SMS Server - RabbitMQ Port")]
        SMSServerRabbitMQPort = 60005,

        [Description("SMS Server - Exchange Name")]
        SMSServerExchangeName = 60006,

        [Description("SMS Server - SMS Queue Key")]
        SMSServerSMSQueueKey = 60007,

        [Description("SMS Server - SMS Routing Key")]
        SMSServerSMSRoutingKey = 60008,

        [Description("SMS Server - SMS Error Queue Key")]
        SMSServerSMSErrorQueueKey = 60009,

        [Description("SMS Server - SMS Error Routing Key")]
        SMSServerSMSErrorRoutingKey = 60010,
        #endregion

        #region Surrvey
        [Description("Surrvey Server - Image Base File Path")] 
        SurrveyServerImageBaseFilePath = 70000,

        [Description("Surrvey Server - URL")]
        SurrveyServerlURL = 70001,

        #endregion

        #region Auth Server

        [Description("Auth Server - URL")]
        AuthServerUrl = 80000,
        #endregion

        #region Geolocation Server

        [Description("Geolocation Server - URL")]
        GeolocationServerUrl = 90000,

        [Description("Geolocation Server - Country Flag Base Url")]
        GeolocationCountryFlagBaseUrl = 90001,
        #endregion
    }
}
