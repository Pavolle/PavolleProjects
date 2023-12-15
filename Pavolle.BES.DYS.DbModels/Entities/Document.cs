using DevExpress.Xpo;
using Pavolle.BES.DYS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("documents")]
    public class Document : BaseObject
    {
        public Document(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("document_type")]
        public EDocumentType DocumentType { get; set; }

        [Persistent("name")]
        public string Name { get; set; }

        [Persistent("path")]
        public string Path { get; set; }

        [Persistent("secure_key")]
        public string SecureKey { get; set; }

        [Persistent("folder_oid")]
        public Folder Folder { get; set; }
    }
}
