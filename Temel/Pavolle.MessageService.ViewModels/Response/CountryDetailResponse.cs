using Pavolle.MessageService.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class CountryDetailResponse : MessageServiceResponseBase
    {
        public CountryDetailViewData Detail { get; set; }
        public List<CityViewData> CityList { get; set; }
    }
}
