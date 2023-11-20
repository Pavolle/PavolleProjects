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
        SystemLanguage
    }
}
