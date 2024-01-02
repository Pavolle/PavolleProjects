using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class GeoServerStatusManager : Singleton<GeoServerStatusManager>
    {

        bool _dbStatus;
        bool _serverStatus;
        bool _settingServerConnectionStatus;
        private GeoServerStatusManager() { }

        public object GetServerSettings(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object GetServerStatus(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public void SetDbStatus(bool dbConnection)
        {
            _dbStatus = dbConnection;
        }

        public void SetServerStatus(bool serverStatus)
        {
            _serverStatus = serverStatus;
        }

        public void SetSettingServerConnectionStatus(bool settingServerConnectionStatus)
        {
            _settingServerConnectionStatus = settingServerConnectionStatus;
        }
    }
}
