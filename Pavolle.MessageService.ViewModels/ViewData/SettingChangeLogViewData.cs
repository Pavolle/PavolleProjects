using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class SettingChangeLogViewData : MessageServiceViewDataBase
    {
        public string User { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
