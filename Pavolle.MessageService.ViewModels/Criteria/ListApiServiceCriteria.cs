using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class ListApiServiceCriteria : MessageServiceCriteriaBase
    {
        public string DefinitionContains { get; set; }
        public string ApiKeyContains { get; set; }
    }
}
