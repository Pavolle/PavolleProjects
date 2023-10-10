using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditOrganizationRequest : MessageServiceRequestBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Langitude { get; set; }
        public double? Latitude { get; set; }
        public long? UpperOrganizationOid { get; set; }
        public long? CountryOid { get; set; }
        public long? CityOid { get; set; }
        public string ZipCode { get; set; }
        public string LogoBase64 { get; set; }
    }
}
