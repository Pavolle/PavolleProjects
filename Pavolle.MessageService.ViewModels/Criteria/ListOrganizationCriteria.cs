using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class ListOrganizationCriteria : MessageServiceCriteriaBase
    {
        public bool? HasSubOrganization { get; set; }
        public long? CountryOid { get; set; }
        public long? CityOid { get; set; }
        public long? UpperOrganizationOid { get; set; }
    }
}
