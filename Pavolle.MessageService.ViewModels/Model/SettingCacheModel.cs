using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class SettingCacheModel
    {
        public long Oid { get; set; }
        public ESettingType SettingType { get; set; }
        public string Value { get; set; }
    }
}
