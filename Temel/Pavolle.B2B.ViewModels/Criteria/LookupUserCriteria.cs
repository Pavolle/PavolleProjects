using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.ViewModels.Criteria
{
    public class LookupUserCriteria : B2BCriteriaBase
    {
        public long? SelectedOganizationOid { get; set; }
        public long? SelectedUserGroupOid { get; set; }
    }
}
