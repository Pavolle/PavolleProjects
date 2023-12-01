using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("ps_password_access_logs")]
    public class PasswordAccessLog : BaseObject
    {
        public PasswordAccessLog(Session session) : base(session)
        {
        }

        [Persistent("guid")]
        public string Guid { get; set; }

        [Persistent("password_oid")]
        public long PasswordOid { get; set; }

        [Persistent("user_oid")]
        public long UserOid { get; set; }

        [Persistent("key")]
        public string Key { get; set; }
    }
}
