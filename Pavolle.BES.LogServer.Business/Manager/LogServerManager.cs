using Pavolle.BES.LogServer.RabbitClient;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.Business.Manager
{
    public class LogServerManager : Singleton<LogServerManager>
    {
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
    }
}
