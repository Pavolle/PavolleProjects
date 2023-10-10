using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class UserGroupDetailResponse : MessageServiceResponseBase
    {
        public UserGroupDetailViewData Detail { get; set; }
        public List<UserGroupAuthViewData> Authorizations { get; set; }
    }
}
