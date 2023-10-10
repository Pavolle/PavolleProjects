using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditApiServiceRequest : MessageServiceRequestBase
    {
        public string ApiDefinition { get; set; }
        public List<ApiServiceAuthRequestModel> Auhtorizations { get; set; }
    }
}
