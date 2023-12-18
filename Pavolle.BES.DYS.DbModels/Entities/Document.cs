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


        [Persistent("unique_code")]
        public string UniqueCode { get; set; }


        [Persistent("document_type")]
        public EDocumentType DocumentType { get; set; }


        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }


        [Persistent("path")]
        [Size(255)]
        public string Path { get; set; }


        [Persistent("secure_key")]
        [Size(100)]
        public string SecureKey { get; set; }


        [Persistent("folder_oid")]
        public Folder Folder { get; set; }


        [Persistent("can_transfer")]
        public bool CanTransfer { get; set; }


        [Persistent("full_path")]
        [Size(255)]
        public string FullPath { get; set; }


        [Persistent("permission_all_organization_user")]
        public bool PermissionAllOrganizationUser { get; set; }
    }
}
