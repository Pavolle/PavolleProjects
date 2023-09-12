using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class CityViewData : B2BViewDataBase
    {
        public string Code { get; set; }
        public long CountryOid { get; set; }
        public string CountryName { get; set; }
        public string Name { get; set; }
    }
}
