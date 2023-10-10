using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class LookupUserCriteria : MessageServiceCriteriaBase
    {
        public long? SelectedOganizationOid { get; set; }
        public long? SelectedUserGroupOid { get; set; }
    }
}
