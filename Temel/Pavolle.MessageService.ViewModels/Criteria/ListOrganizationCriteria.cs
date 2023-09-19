namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class ListOrganizationCriteria : MessageServiceCriteriaBase
    {
        public long? CountryOid { get; set; }
        public long? CityOid { get; set; }
        public long? UpperOrganizationOid { get; set; }
    }
}
