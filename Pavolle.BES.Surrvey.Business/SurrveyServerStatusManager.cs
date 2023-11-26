using log4net;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.Business
{
    public class SurrveyServerStatusManager : Singleton<SurrveyServerStatusManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SurrveyServerStatusManager));
        bool _settingServerConnectionStatus = false;
        List<SettingViewData> _settingList;
        private SurrveyServerStatusManager() { }

        public object GetServerSettings(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object GetServerStatus(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

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


        public void SetSettingServerConnectionStatus(bool status)
        {
            _settingServerConnectionStatus=status;
        }
    }
}
