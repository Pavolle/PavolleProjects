using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("password_categories")]
    public class PasswordCategory : BaseObject
    {
        public PasswordCategory(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("definition")]
        [Size(500)]
        public string Definition { get; set; }

        [Persistent("is_personel")]
        public bool IsPersonal { get; set; }

        [Persistent("belong_user_oid")]
        public long? BelongUserOid { get; set; }
    }
}
