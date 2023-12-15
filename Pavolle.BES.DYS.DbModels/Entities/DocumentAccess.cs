using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("document_access")]
    public class DocumentAccess : BaseObject
    {
        public DocumentAccess(Session session) : base(session)
        {
        }

        [Persistent("document_oid")]
        public Document Document { get; set; }

        [Persistent("user_oid")]
        public long UserOid { get; set; }

        [Persistent("has_access")]
        public bool HasAccess { get; set; }
    }
}
