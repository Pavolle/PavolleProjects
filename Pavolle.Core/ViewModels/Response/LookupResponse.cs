using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.Core.ViewModels.Response
{
    public class LookupResponse : ResponseBase
    {
        public List<LookupViewData> DataList { get; set; }
    }
}
