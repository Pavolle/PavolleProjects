using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class SettingViewData : MessageServiceViewDataBase
    {
        public string SettingName { get; set; }
        public string Value { get; set; }
    }
}
