using log4net;
using Pavolle.BES.LogServer.RabbitClient;
using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.Business.Manager
{
    public class LogServerManager : Singleton<LogServerManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(LogServerManager));
        List<SettingViewData> _settingList;
        private LogServerManager() { }

        public ResponseBase Save(LogRequest request)
        {
            if(request==null)
            {
                return new ResponseBase
                {
                    ErrorMessage = "Data format is not correct!"
                };
            }
            request.TimeToArrive=DateTime.Now;
            bool writeResult= RabbitMQManager.Instance.ProduceLogMessage(request);
            if (!writeResult)
            {
                return new ResponseBase
                {
                    ErrorMessage = "Log could not write to queue!"
                };
            }
            _log.Debug(request.LogBase + "Log writed to queue");
            return new ResponseBase() { SuccessMessage = "OK" };
        }


    }
}
