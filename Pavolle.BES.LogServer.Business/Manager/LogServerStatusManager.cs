using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.LogServer.ViewModels.Response;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.Business.Manager
{
    public class LogServerStatusManager : Singleton<LogServerStatusManager>
    {
        private LogServerStatusManager() { }

        bool _elastichSearchStatus = false;
        bool _rabbitMQStatus=false;
        bool _serverStatus = false;
        bool _settingServerConnectionStatus=false;

        public LogServerStatusResponse GetServerStatus(LogServerRequestBase request)
        {
            return new LogServerStatusResponse
            {
                ElasticSearchStatus = _elastichSearchStatus,
                ElasticSearchStatusString = _elastichSearchStatus ? "Ready" : "Not Ready",
                RabbitMQStatus = _rabbitMQStatus,
                RabbitMQStatusString = _rabbitMQStatus ? "Ready" : "Not Ready",
                ServerStatus = _serverStatus,
                ServerStatusString = _serverStatus ? "Ready" : "Not Ready",
                SettingServerConnectionStatus = _settingServerConnectionStatus,
                SettingServerConnectionStatusString = _settingServerConnectionStatus ? "Connected" : "Not Connected"
            };
        }

        public void SetRabbitMQStatus(bool status)
        {
            _rabbitMQStatus = status;
        }

        public void SetServerStatus(bool status)
        {
            _serverStatus = status;
        }

        public void SetElastichSearchStatus(bool status)
        {
            _elastichSearchStatus = status;
        }

        public void SetSettingServerConnectionStatus(bool status)
        {
            _settingServerConnectionStatus = status;
        }
    }
}
