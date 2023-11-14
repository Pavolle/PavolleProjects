using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.ViewModels.Response
{
    public class LogServerSettingsResponse : ResponseBase
    {
        public string LogServerRabbitMQPort { get; set; }
        public string LogServerRabbitMQHostname { get; set; }
        public string LogServerRabbitMQVHost { get; set; }
        public string LogServerRabbitMQPassword { get; set; }
        public string LogServerRabbitMQUsername { get; set; }
        public string LogServerExchangeName { get; set; }
        public string LogServerLogRoutingKey { get; set; }
        public string LogServerLogErrorQueueKey { get; set; }
        public string LogServerLogQueueKey { get; set; }
        public string LogServerLogErrorRoutingKey { get; set; }
        public string SettingServerUrl { get; set; }
    }
}
