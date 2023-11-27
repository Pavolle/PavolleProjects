using log4net;
using Pavolle.BES.SettingServer.ViewModels.Request;
using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Manager;
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
        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusManager));
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

        public SettingsServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            return new SettingsServerStatusResponse
            {
                AppInfo = WebAppInfoManager.Instance.GetAppCode(),
                Version = WebAppInfoManager.Instance.GetVersion(),
                ReleaseDate = WebAppInfoManager.Instance.GetReleaseDate(),
                DbStatus = _dbStatus,
                DbStatusString=_dbStatus?"Connected":"Connection Error Occured!",
                ServerStatus = _serverStatus && _dbStatus,
                ServerStatusString = _serverStatus && _dbStatus ? "Ready" : "Not Ready!",
            };
        }
    }
}
