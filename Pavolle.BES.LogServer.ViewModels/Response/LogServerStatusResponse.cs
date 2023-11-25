using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.ViewModels.Response
{
    public class LogServerStatusResponse : ServerStatusResponseBase
    {
        public bool RabbitMQStatus { get; set; }
        public string RabbitMQStatusString { get; set; }
        public bool ElasticSearchStatus { get; set; }
        public string ElasticSearchStatusString { get; set; }
        public long WaitForWritingCount { get; set; }
        public long WriteErrorCount { get; set; }
        public bool SettingServerConnectionStatus { get; set; }
        public string SettingServerConnectionStatusString { get; set; }
    }
}
