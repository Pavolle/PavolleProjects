using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class AddCountryRequest : B2BRequestBase
    {
        public string ISOCode2 { get; set; }
        public string ISOCode3 { get; set; }
        public string PhoneCode { get; set; }
        public string Name { get; set; }
    }
}
