using DevExpress.Xpo;
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

        [Persistent("owner_organization_oid")]
        public long OwnedOrganizationOid { get; set; }

        [Persistent("owner_person_oid")]
        public long? OwnedPersonOid { get; set; }

        [Persistent("name")]
        public string Name { get; set; }

        [Persistent("path")]
        public string Path { get; set; }

        [Persistent("is_original")]
        public bool IsOrginal { get; set; }

        [Persistent("rfid_tag")]
        public string RfidTag { get; set; }

        [Persistent("file_oid")]
        public File File { get; set; }

        [Persistent("physical_file_oid")]
        public PhysicalFile PhysicalFile { get; set; }
    }
}
