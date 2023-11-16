using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("physical_files")]
    public class PhysicalFile : BaseObject
    {
        public PhysicalFile(Session session) : base(session)
        {
        }


        [Persistent("owner_organization_oid")]
        public long OwnedOrganizationOid { get; set; }

        [Persistent("owner_person_oid")]
        public long? OwnedPersonOid { get; set; }

        [Persistent("location_info")]
        public string LocationInfo { get; set; }

        [Persistent("cabinet_oid")]
        public long CabinetOid { get; set; }

        [Persistent("code")]
        public string Code { get; set; }

        [Persistent("has_protection")]
        public bool HasProtection { get; set; }

        [Persistent("rfid_tag")]
        public string RfidTag { get; set; }

        [Persistent("file_limit")]
        public int FileLimit { get; set; }

        [Persistent("current_file_count")]
        public int CurrentFileCount { get; set; }
    }
}
