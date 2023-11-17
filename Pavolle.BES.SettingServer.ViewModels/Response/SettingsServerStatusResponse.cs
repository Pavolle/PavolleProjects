using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.ViewModels.Response
{
    public class SettingsServerStatusResponse : ResponseBase
    {
        public bool DbStatus { get; set; }
        public string DbStatusString { get; set; }

        public bool ServerStatus { get; set; }
        public string ServerStatusString { get; set; }
        public string AppInfo { get; set; }
    }
}
