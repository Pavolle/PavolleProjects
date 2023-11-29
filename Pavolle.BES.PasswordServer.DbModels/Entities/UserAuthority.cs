using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("user_authorities")]
    public class UserAuthority : BaseObject
    {
        public UserAuthority(Session session) : base(session)
        {
        }

        [Persistent("user_oid")]
        public long UserOid { get; set; }

        [Persistent("password")]
        public Pasword Pasword { get; set; }

        [Persistent("is_authority")]
        public bool IsAuthority { get; set; }
    }
}
