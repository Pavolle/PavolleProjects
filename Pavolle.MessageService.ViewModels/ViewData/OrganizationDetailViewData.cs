using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class OrganizationDetailViewData : MessageServiceViewDataBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public double? Langitude { get; set; }
        public double? Latitude { get; set; }
        public long? UpperOrganizationOid { get; set; }
        public string UpperOrganizationName { get; set; }
        public long? CountryOid { get; set; }
        public string CountryName { get; set; }
        public long? CityOid { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public string LogoBase64 { get; set; }
    }
}
