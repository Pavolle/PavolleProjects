using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Model
{
    public class SettingCacheModel
    {
        public long Oid { get; set; }
        public ESettingType SettingType { get; set; }
        public string Value { get; set; }
    }
}
