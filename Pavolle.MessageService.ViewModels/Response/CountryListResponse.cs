using Pavolle.MessageService.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class CountryListResponse : MessageServiceResponseBase
    {
        public List<CountryViewData> DataList { get; set; }
    }
}
