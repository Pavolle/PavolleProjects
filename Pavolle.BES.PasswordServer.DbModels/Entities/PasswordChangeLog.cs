using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("ps_password_change_log")]
    public class PasswordChangeLog : BaseObject
    {
        public PasswordChangeLog(Session session) : base(session)
        {
        }

        [Persistent("password_oid")]
        public Password Password { get; set; }


        [Persistent("old_value")]
        [Size(1000)]
        public string Old { get; set; }


        [Persistent("user_oid")]
        public long UserOid { get; set; }
    }
}
