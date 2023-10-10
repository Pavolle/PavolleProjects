using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class TranslateDataDetailResponse : MessageServiceResponseBase
    {
        public TranslateDataDetailViewData Detail { get; set; }
        public List<TranslateDataChangeLogViewData> ChangeLogViewData { get; set; }
    }
}
