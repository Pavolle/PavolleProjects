using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class ApiServiceDetailResponse : MessageServiceResponseBase
    {
        public ApiServiceDetailViewData Detail { get; set; }
        public List<ApiServiceAuthViewData> Authorization { get; set; }
    }
}
