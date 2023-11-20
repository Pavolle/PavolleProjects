using log4net;
using Pavolle.BES.LogServer.RabbitClient;
using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
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

        public bool InitializeSettings()
        {
            var settingListResponse = SettingServiceManager.Instance.GetSettingsList();
            if (settingListResponse == null)
            {
                return false;
            }
            if (!settingListResponse.Success) { return false; }
            if (settingListResponse.DataList == null) { return false; }
            _settingList = settingListResponse.DataList;
            return true;
        }

        public string GetSetting(ESettingType settingType)
        {
            return _settingList.FirstOrDefault(t=>t.SettingType == settingType).Value;
        }

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
