using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class SettingDetailResponse : MessageServiceResponseBase
    {
        public SettingDetailViewData Detail { get; set; }
        public List<SettingChangeLogViewData> ChangeLogs { get; set; }
    }
}
