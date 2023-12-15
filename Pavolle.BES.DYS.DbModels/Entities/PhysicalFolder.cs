using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    public class PhysicalFolder : BaseObject
    {
        public PhysicalFolder(Session session) : base(session)
        {
        }


        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("has_protection")]
        public bool HasProtection { get; set; }

        [Persistent("file_limit")]
        public int FileLimit { get; set; }

        [Persistent("current_file_count")]
        public int CurrentFileCount { get; set; }

        [Persistent("rfid_tag")]
        public string RfidTag { get; set; }

        [Persistent("code")]
        public string Code { get; set; }
    }
}
