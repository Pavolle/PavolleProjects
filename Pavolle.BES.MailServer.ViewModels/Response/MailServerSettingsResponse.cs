using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.ViewModels.Response
{
    public class MailServerSettingsResponse : ServerStatusResponseBase
    {
        public bool RabbitMQStatus { get; set; }
        public string RabbitMQStatusString { get; set; }
        public bool SettingServerConnectionStatus { get; set; }
        public string SettingServerConnectionStatusString { get; set; }
        public DateTime SettingsReloadTime { get; set; }
        public bool DbStatus { get; set; }
        public string DbStatusString { get; set; }
    }
}
