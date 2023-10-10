using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.MessageService.ViewModels.Response
{
    public class CountryDetailResponse : MessageServiceResponseBase
    {
        public CountryDetailViewData Detail { get; set; }
        public List<CityViewData> CityList { get; set; }
    }
}
