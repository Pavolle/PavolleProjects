using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("password_histories")]
    public class PasswordHistory : BaseObject
    {
        public PasswordHistory(Session session) : base(session)
        {
        }

        [Persistent("password_oid")]
        public Password Password { get; set; }


        [Persistent("old_value")]
        public string Old { get; set; }


        [Persistent("user_oid")]
        public long UserOid { get; set; }
    }
}
