using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.ViewModels.Response
{
    public class SettingDetailResponse : ResponseBase
    {

        public SettingViewData Detail { get; set; }
        public List<SettingChangeLogViewData> ChangeLogs { get; set; }
    }
}
