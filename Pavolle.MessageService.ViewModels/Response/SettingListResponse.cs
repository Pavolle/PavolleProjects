using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class SettingListResponse : MessageServiceResponseBase
    {
        public List<SettingViewData> DataList { get; set; }
    }
}
