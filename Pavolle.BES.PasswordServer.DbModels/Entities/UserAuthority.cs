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
        public Password Pasword { get; set; }


        [Persistent("can_change")]
        public bool CanChange { get; set; }


        [Persistent("is_owner")]
        public bool IsOwner { get; set; }


        [Persistent("can_access")]
        public bool CanAccess { get; set; }
    }
}
