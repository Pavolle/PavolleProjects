namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class ListUserCriteria : MessageServiceCriteriaBase
    {
        public long? SelectedOrganizationOid { get; set; }
        public long? SelectedUserGroupOid { get; set; }
        public string UsernameContains { get; set; }
        public string PhoneNumberContains { get; set; }
        public string EmailContains { get; set; }
    }
}
