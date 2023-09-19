using Pavolle.B2B.Common.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class AddCityRequest : B2BRequestBase
    {
        public long? CountryOid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
