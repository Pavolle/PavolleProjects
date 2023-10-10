using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class LookupOrganizationCriteria : MessageServiceCriteriaBase
    {
        public long? UpperOrganizationOid { get; set; }
    }
}
