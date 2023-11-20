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
        [Description("Db Connection")]
        DbConnection = 0,

        [Description("Log Server Url")]
        LogServerUrl = 1,

        [Description("Log Server - RabbitMQ Username")]
        LogServerRabbitMQUsername,

        [Description("Log Server - RabbitMQ Password")]
        LogServerRabbitMQPassword,

        [Description("Log Server - RabbitMQ VHost")]
        LogServerRabbitMQVHost,

        [Description("Log Server - RabbitMQ Hostname")]
        LogServerRabbitMQHostname,

        [Description("Log Server - RabbitMQ Port")]
        LogServerRabbitMQPort,

        [Description("Log Server - Exchange Name")]
        LogServerExchangeName,

        [Description("Log Server - Log Queue Key")]
        LogServerLogQueueKey,

        [Description("Log Server - Log Routing Key")]
        LogServerLogRoutingKey,

        [Description("Log Server - Log Error Queue Key")]
        LogServerLogErrorQueueKey,

        [Description("Log Server - Log Error Routing Key")]
        LogServerLogErrorRoutingKey,

        [Description("DYS - Base File Path")]
        DYSBaseFilePath,

        [Description("Translate Server Base Url")]
        TranslateServerBaseUrl,

        [Description("Default Language")]
        DefaultLanguage,

        [Description("System Language")]
        SystemLanguage,



        [Description("Mail Server - RabbitMQ Username")]
        MailServerRabbitMQUsername,

        [Description("Mail Server - RabbitMQ Password")]
        MailServerRabbitMQPassword,

        [Description("Mail Server - RabbitMQ VHost")]
        MailServerRabbitMQVHost,

        [Description("Mail Server - RabbitMQ Hostname")]
        MailServerRabbitMQHostname,

        [Description("Mail Server - RabbitMQ Port")]
        MailServerRabbitMQPort,

        [Description("Mail Server - Exchange Name")]
        MailServerExchangeName,

        [Description("Mail Server - Mail Queue Key")]
        MailServerMailQueueKey,

        [Description("Mail Server - Mail Routing Key")]
        MailServerMailRoutingKey,

        [Description("Mail Server - Mail Error Queue Key")]
        MailServerMailErrorQueueKey,

        [Description("Mail Server - Mail Error Routing Key")]
        MailServerMailErrorRoutingKey,



        [Description("SMS Server - RabbitMQ Username")]
        SMSServerRabbitMQUsername,

        [Description("SMS Server - RabbitMQ Password")]
        SMSServerRabbitMQPassword,

        [Description("SMS Server - RabbitMQ VHost")]
        SMSServerRabbitMQVHost,

        [Description("SMS Server - RabbitMQ Hostname")]
        SMSServerRabbitMQHostname,

        [Description("SMS Server - RabbitMQ Port")]
        SMSServerRabbitMQPort,

        [Description("SMS Server - Exchange Name")]
        SMSServerExchangeName,

        [Description("SMS Server - SMS Queue Key")]
        SMSServerSMSQueueKey,

        [Description("SMS Server - SMS Routing Key")]
        SMSServerSMSRoutingKey,

        [Description("SMS Server - SMS Error Queue Key")]
        SMSServerSMSErrorQueueKey,

        [Description("SMS Server - SMS Error Routing Key")]
        SMSServerSMSErrorRoutingKey,
    }
}
