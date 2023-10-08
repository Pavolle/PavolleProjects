using DevExpress.Xpo;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("settings")]
    public class Setting : BaseObject
    {
        public Setting(Session session) : base(session) {}

        [Persistent("setting_type")]
        public ESettingType SettingType { get; set; }

        [Persistent("setting_name")]
        [Size(1000)]
        public string SettingName { get; set; }

        [Persistent("value")]
        [Size(1000)]
        public string Value { get; set; }

    }
}
