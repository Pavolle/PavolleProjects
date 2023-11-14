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

        [Description("RabbitMQ Username")]
        RabbitMQUsername,

        [Description("RabbitMQ Password")]
        RabbitMQPassword,

        [Description("RabbitMQ VHost")]
        RabbitMQVHost,

        [Description("RabbitMQ Hostname")]
        RabbitMQHostname,

        [Description("RabbitMQ Port")]
        RabbitMQPort,
    }
}
