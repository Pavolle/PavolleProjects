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
        public string DbStatus { get; set; }
        public string ServerStatus { get; set; }
    }
}
