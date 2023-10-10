using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class CityViewData : MessageServiceViewDataBase
    {
        public string Code { get; set; }
        public long CountryOid { get; set; }
        public string CountryName { get; set; }
        public string Name { get; set; }
    }
}
