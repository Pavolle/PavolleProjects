using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class CountryViewData : B2BViewDataBase
    {
        public string ISOCode2 { get; set; }
        public string ISOCode3 { get; set; }
        public string PhoneCode { get; set; }
        public string Name { get; set; }
    }
}
