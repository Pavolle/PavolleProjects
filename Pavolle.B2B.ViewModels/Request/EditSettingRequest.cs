using Pavolle.B2B.Common.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Request
{
    public class EditSettingRequest : B2BRequestBase
    {
        public string SettingName { get; set; }
        public string Value { get; set; }
    }
}
