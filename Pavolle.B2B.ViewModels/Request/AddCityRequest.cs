using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class AddCityRequest : B2BRequestBase
    {
        public long? CountryOid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
