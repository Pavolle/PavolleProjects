using DevExpress.Xpo;
using Pavolle.BES.PasswordServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("ps_passwords")]
    public class Password : BaseObject
    {

        public Password(Session session) : base(session)
        {
        }

        [Persistent("owner_organization_oid")]
        public long OwnerOrganizationOid { get; set; }

        [Persistent("owner_user_oid")]
        public long? OwnerUserOid { get; set; }

        [Persistent("encryted_pasword")]
        [Size(1000)]
        public string EncrytedPasword { get; set; }

        [Persistent("definition")]
        public string Definition { get; set; }

        [Persistent("owner_type")]
        public EPasswordOwnerType OwnerType { get; set; }
    }
}
