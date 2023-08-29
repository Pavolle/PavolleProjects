using DevExpress.Xpo;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("settings")]
    public class SystemSettings : BaseObject
    {
        public SystemSettings(Session session) : base(session)
        {
        }

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
