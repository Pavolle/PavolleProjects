using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class AddCountryRequest : MessageServiceRequestBase
    {
        public string ISOCode2 { get; set; }
        public string ISOCode3 { get; set; }
        public string PhoneCode { get; set; }
        public string Name { get; set; }
    }
}
