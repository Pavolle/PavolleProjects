using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("setting_change_logs")]
    public class SettingChangeLog : BaseObject
    {
        public SettingChangeLog(Session session) : base(session)
        {
        }

        [Persistent("setting_oid")]
        public Setting Setting { get; set; }

        [Persistent("user_oid")]
        public User User { get; set; }

        [Persistent("old_value")]
        [Size(1000)]
        public string OldValue { get; set; }

        [Persistent("new_value")]
        [Size(1000)]
        public string NewValue { get; set; }
    }
}
