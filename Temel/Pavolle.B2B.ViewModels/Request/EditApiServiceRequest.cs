using Pavolle.B2B.Common.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class EditApiServiceRequest : B2BRequestBase
    {
        public string ApiDefinition { get; set; }
        public List<ApiServiceAuthRequestModel> Auhtorizations { get; set; }
    }
}
