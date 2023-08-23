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
    public class Settings : BaseObject
    {
        public Settings(Session session) : base(session)
        {
        }

        [Persistent("setting_type")]
        public ESettingType SettingType { get; set; }

        [Persistent("value")]
        public string Value { get; set; }
    }
}
