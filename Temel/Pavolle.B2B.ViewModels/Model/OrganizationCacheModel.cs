using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Model
{
    public class OrganizationCacheModel
    {
        public long Oid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
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
