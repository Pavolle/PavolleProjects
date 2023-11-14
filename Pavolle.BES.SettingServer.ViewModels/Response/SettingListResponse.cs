using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.ViewModels.Response
{
    public class SettingListResponse : ResponseBase
    {
        public List<SettingViewData> DataList { get; set; }
    }
}
