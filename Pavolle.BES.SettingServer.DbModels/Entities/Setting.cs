using DevExpress.Xpo;
using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.DbModels.Entities
{
    [Persistent(SettingServerConsts.DbConsts.IsPostgres ? "sssettings" : "settings")]
    public class Setting : BaseObject
    {
        public Setting(Session session) : base(session)
        {
        }

        [Persistent("setting_type")]
        public ESettingType SettingType { get; set; }

        [Persistent("category")]
        public ESettingCategory Category { get; set; }

        [Persistent("value")]
        [Size(1000)]
        public string Value { get; set; }

        //Şifreleri arayüzde gizlemek için bu şekilde bir parametre tanımladık.
        [Persistent("is_critical_data")]
        public bool IsCriticalData { get; set; }
    }
}
