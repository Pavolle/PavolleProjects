using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.ViewModels.Criteria
{
    public class ListOrganizationCriteria : B2BCriteriaBase
    {
        public bool? HasSubOrganization { get; set; }
        public long? CountryOid { get; set; }
        public long? CityOid { get; set; }
        public long? UpperOrganizationOid { get; set; }
    }
}
