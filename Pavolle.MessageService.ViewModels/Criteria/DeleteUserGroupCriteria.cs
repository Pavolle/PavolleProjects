using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class DeleteUserGroupCriteria : MessageServiceCriteriaBase
    {
        public bool? ForceDelete { get; set; }
    }
}