using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("user_roles")]
    public class UserRole : BaseObject
    {
        public UserRole(Session session) : base(session)
        {
        }

        [Persistent("user_oid")]
        public User User { get; set; }

        [Persistent("role_oid")]
        public Role Role { get; set; }

        [Persistent("is_valid")]
        public bool IsValid { get; set; }
    }
}
