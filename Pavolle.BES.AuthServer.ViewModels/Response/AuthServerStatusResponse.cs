using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Response
{
    public class AuthServerStatusResponse : ResponseBase
    {
        public string AppInfo { get; set; }
        public string Version { get; set; }
        public string ReleaseDate { get; set; }
        public bool DbStatus { get; set; }
        public string DbStatusString { get; set; }
        public bool ServerStatus { get; set; }
        public string ServerStatusString { get; set; }
        public bool SettingServerConnectionStatus { get; set; }
        public string SettingServerConnectionStatusString { get; set; }
        public DateTime SettingsReloadTime { get; set; }
        public bool LoadUserStatus { get; set; }
        public string LoadUserStatusString { get; set; }
    }
}
