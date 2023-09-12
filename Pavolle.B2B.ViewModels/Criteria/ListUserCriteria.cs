using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.ViewModels.Criteria
{
    public class ListUserCriteria : B2BCriteriaBase
    {
        public long? SelectedOrganizationOid { get; set; }
        public long? SelectedUserGroupOid { get; set; }
        public string UsernameContains { get; set; }
        public string PhoneNumberContains { get; set; }
        public string EmailContains { get; set; }
    }
}
