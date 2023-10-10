using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class SettingDetailResponse : MessageServiceResponseBase
    {
        public SettingDetailViewData Detail { get; set; }
        public List<SettingChangeLogViewData> ChangeLogs { get; set; }
    }
}
