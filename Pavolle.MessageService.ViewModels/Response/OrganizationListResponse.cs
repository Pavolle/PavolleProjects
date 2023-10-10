using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class OrganizationListResponse : MessageServiceResponseBase
    {
        public List<OrganizationViewData> DataList { get; set; }
    }
}
