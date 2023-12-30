using Pavolle.Core.Enums;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.ViewModels.Response
{
    public class MailServereStatusResponse : ResponseBase
    {
        public ELanguage Language { get; set; }
        public ELanguage SystemLanguage { get; set; }
        public string SettingServerBaseUrl { get; set; }
        public string TranslateServerBaseUrl { get; set; }
        public string MailServerRabbitMQUsername { get; set; }
        public string MailServerRabbitMQPassword { get; set; }
        public string MailServerRabbitMQHostname { get; set; }
        public string MailServerRabbitMQVHost { get; set; }
        public string MailServerRabbitMQPort { get; set; }
        public string MailServerExchangeName { get; set; }
        public string MailServerMailQueueKey { get; set; }
        public string MailServerMailRoutingKey { get; set; }
        public string MailServerMailErrorQueueKey { get; set; }
        public string MailServerMailErrorRoutingKey { get; set; }
    }
}
