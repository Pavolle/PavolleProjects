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
        DbConnection = 100,

        [Description("Default Language")]
        DefaultLanguage=101,

        [Description("System Language")]
        SystemLanguage=102,
        #endregion

        #region Log Server
        [Description("Log Server Url")]
        LogServerUrl = 201,

        [Description("Log Server - RabbitMQ Username")]
        LogServerRabbitMQUsername = 202,

        [Description("Log Server - RabbitMQ Password")]
        LogServerRabbitMQPassword =203,

        [Description("Log Server - RabbitMQ VHost")]
        LogServerRabbitMQVHost = 204,

        [Description("Log Server - RabbitMQ Hostname")]
        LogServerRabbitMQHostname = 205,

        [Description("Log Server - RabbitMQ Port")]
        LogServerRabbitMQPort = 206,

        [Description("Log Server - Exchange Name")]
        LogServerExchangeName = 207,

        [Description("Log Server - Log Queue Key")]
        LogServerLogQueueKey = 208,

        [Description("Log Server - Log Routing Key")]
        LogServerLogRoutingKey = 209,

        [Description("Log Server - Log Error Queue Key")]
        LogServerLogErrorQueueKey=210,

        [Description("Log Server - Log Error Routing Key")]
        LogServerLogErrorRoutingKey = 211,
        #endregion

        #region DYS
        [Description("DYS - Base File Path")]
        DYSBaseFilePath = 300,
        #endregion

        #region Translate Server
        [Description("Translate Server Base Url")]
        TranslateServerBaseUrl = 400,
        #endregion

        #region Mail Server
        [Description("Mail Server URL")]
        MailServerUrl = 500,

        [Description("Mail Server - RabbitMQ Username")]
        MailServerRabbitMQUsername = 501,

        [Description("Mail Server - RabbitMQ Password")]
        MailServerRabbitMQPassword =502,

        [Description("Mail Server - RabbitMQ VHost")]
        MailServerRabbitMQVHost =503,

        [Description("Mail Server - RabbitMQ Hostname")]
        MailServerRabbitMQHostname = 504,

        [Description("Mail Server - RabbitMQ Port")]
        MailServerRabbitMQPort = 505,

        [Description("Mail Server - Exchange Name")]
        MailServerExchangeName = 506,

        [Description("Mail Server - Mail Queue Key")]
        MailServerMailQueueKey =507,

        [Description("Mail Server - Mail Routing Key")]
        MailServerMailRoutingKey = 508,

        [Description("Mail Server - Mail Error Queue Key")]
        MailServerMailErrorQueueKey = 509,

        [Description("Mail Server - Mail Error Routing Key")]
        MailServerMailErrorRoutingKey=510,

        [Description("Mail Server - Pavolle Hostname")]
        MailServerPavolleHostname = 511,

        [Description("Mail Server - Pavolle Username")]
        MailServerPavolleUsername = 512,

        [Description("Mail Server - Pavolle Password")]
        MailServerPavollePassword = 513,

        [Description("Mail Server - Pavolle Port")]
        MailServerPavollePort = 514,

        [Description("Mail Server - Pavolle Port")]
        MailServerCurrentIntegration = 515,
        #endregion

        #region SMS Server
        [Description("SMS Server URL")]
        SMSServerUrl = 600,

        [Description("SMS Server - RabbitMQ Username")]
        SMSServerRabbitMQUsername = 601,

        [Description("SMS Server - RabbitMQ Password")]
        SMSServerRabbitMQPassword = 602,

        [Description("SMS Server - RabbitMQ VHost")]
        SMSServerRabbitMQVHost =603,

        [Description("SMS Server - RabbitMQ Hostname")]
        SMSServerRabbitMQHostname =604,

        [Description("SMS Server - RabbitMQ Port")]
        SMSServerRabbitMQPort =605,

        [Description("SMS Server - Exchange Name")]
        SMSServerExchangeName =606,

        [Description("SMS Server - SMS Queue Key")]
        SMSServerSMSQueueKey = 607,

        [Description("SMS Server - SMS Routing Key")]
        SMSServerSMSRoutingKey =608,

        [Description("SMS Server - SMS Error Queue Key")]
        SMSServerSMSErrorQueueKey = 609,

        [Description("SMS Server - SMS Error Routing Key")]
        SMSServerSMSErrorRoutingKey =610,
        #endregion

        #region Surrvey
        [Description("Surrvey Server - Image Base File Path")] 
        SurrveyServerImageBaseFilePath = 700,

        [Description("Surrvey Server - URL")]
        SurrveyServerlURL =701,

        #endregion

        #region Auth Server

        [Description("Auth Server - URL")]
        AuthServerUrl = 800,
        #endregion
    }
}
