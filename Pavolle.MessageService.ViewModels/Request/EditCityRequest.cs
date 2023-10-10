using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditCityRequest : MessageServiceRequestBase
    {
        public long? CountryOid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
