namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class LookupUserCriteria : MessageServiceCriteriaBase
    {
        public long? UserGroupOid { get; set; }
        public long? OganizationOid { get; set; }
    }
}
