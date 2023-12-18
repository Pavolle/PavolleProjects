using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("role_document_access")]
    public class DocumentRoleAccess : BaseObject
    {
        public DocumentRoleAccess(Session session) : base(session)
        {
        }

        [Persistent("document_oid")]
        public Document Document { get; set; }

        [Persistent("all_organization_user")]
        public bool AllOrganizationUser { get; set; }

        [Persistent("role_oid")]
        public long RoleOid { get; set; }

        [Persistent("has_access")]
        public bool HasAccess { get; set; }
    }
}
