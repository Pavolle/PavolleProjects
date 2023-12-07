using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.ViewModels.Response
{
    public class PasswordServerStatusResponse : ServerStatusResponseBase
    {
        public bool DbStatus { get; set; }
        public string DbStatusString { get; set; }
        public bool SettingServerConnectionStatus { get; set; }
        public string SettingServerConnectionStatusString { get; set; }
        public DateTime SettingsReloadTime { get; set; }
    }
}
