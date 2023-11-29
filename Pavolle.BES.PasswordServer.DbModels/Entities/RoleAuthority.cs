using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    public class RoleAuthority : BaseObject
    {
        public RoleAuthority(Session session) : base(session)
        {
        }

        public long RoleOid { get; set; }
        public Pasword Pasword { get; set; }
        public bool IsAuthority { get; set; }
    }
}
