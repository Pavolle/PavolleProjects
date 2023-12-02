using Pavolle.BES.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.ViewModels.Response
{
    public class JobServerStatusResponse : ServerStatusResponseBase
    {
        public bool DbStatus { get; set; }
        public string DbStatusString { get; set; }
        public DateTime SettingsReloadTime { get; set; }
        public string SettingServerConnectionStatusString { get; set; }
        public bool SettingServerConnectionStatus { get; set; }
    }
}
