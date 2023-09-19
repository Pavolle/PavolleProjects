using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class SettingChangeLogViewData : B2BViewDataBase
    {
        public string User { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
