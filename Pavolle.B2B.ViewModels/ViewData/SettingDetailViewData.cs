using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class SettingDetailViewData : B2BViewDataBase
    {
        public ESettingType SettingType { get; set; }
        public string SettingName { get; set; }
        public string Value { get; set; }
    }
}
