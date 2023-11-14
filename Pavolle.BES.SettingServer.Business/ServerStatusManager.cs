using Pavolle.BES.SettingServer.ViewModels.Request;
using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Business
{
    public class ServerStatusManager : Singleton<ServerStatusManager>
    {
        private ServerStatusManager() { }

        string _dbStatus = "Connection Error";
        string _serverStatus = "Not Ready";

        public void SetDbStatus(bool status)
        {
            if(status) { _dbStatus = "Ready"; }
            else { _dbStatus = "Connection Error"; }
        }

        public void SetSeverStatus(bool status)
        {
            if (status) { _serverStatus = "Ready"; }
            else { _serverStatus = "Not Ready"; }
        }

        public SettingsServerStatusResponse GetServerStatus(SettingsServerRequestBase request)
        {
            return new SettingsServerStatusResponse
            {
                DbStatus = _dbStatus,
                ServerStatus = _serverStatus
            };
        }
    }
}
