using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("role_authorities")]
    public class RoleAuthority : BaseObject
    {
        public RoleAuthority(Session session) : base(session)
        {
        }

        [Persistent("role_oid")]
        public long RoleOid { get; set; }


        [Persistent("password")]
        public Password Pasword { get; set; }


        [Persistent("can_change")]
        public bool CanChange { get; set; }


        [Persistent("can_access")]
        public bool CanAccess { get; set; }
    }
}
