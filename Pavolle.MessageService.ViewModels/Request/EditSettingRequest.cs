using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditSettingRequest : MessageServiceRequestBase
    {
        public string SettingName { get; set; }
        public string Value { get; set; }
    }
}
