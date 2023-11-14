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

        bool _dbStatus = false;
        bool _serverStatus = false;

        public void SetDbStatus(bool status)
        {
            _dbStatus = status;
        }

        public void SetSeverStatus(bool status)
        {
            _serverStatus = status;
        }

        public SettingsServerStatusResponse GetServerStatus(SettingsServerRequestBase request)
        {
            return new SettingsServerStatusResponse
            {
                DbStatus = _dbStatus,
                DbStatusString=_dbStatus?"Ready":"Connection Error",
                ServerStatus = _serverStatus,
                ServerStatusString = _dbStatus ? "Ready" : "Not Ready",
            };
        }
    }
}
