using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class UserGroupListResponse : MessageServiceResponseBase
    {
        public List<UserGroupViewData> DataList { get; set; }
    }
}
