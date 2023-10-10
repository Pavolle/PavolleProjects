using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class ListUserGroupCriteria : MessageServiceCriteriaBase
    {
        public long? SelectedOrganizationOid { get; set; }
    }
}
