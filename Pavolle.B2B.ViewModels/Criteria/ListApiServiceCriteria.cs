using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.ViewModels.Criteria
{
    public class ListApiServiceCriteria : B2BCriteriaBase
    {
        public string DefinitionContains { get; set; }
        public string ApiKeyContains { get; set; }
    }
}
