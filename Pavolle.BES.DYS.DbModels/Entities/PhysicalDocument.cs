using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("physical_files")]
    public class PhysicalDocument : BaseObject
    {
        public PhysicalDocument(Session session) : base(session)
        {
        }

        [Persistent("is_original_document")]
        public bool IsOrginalDocument { get; set; }

        [Persistent("physical_folder_oid")]
        public PhysicalFolder PhysicalFolder { get; set; }

        [Persistent("rfid_tag")]
        public string RfidTag { get; set; }

        [Persistent("document_oid")]
        public Document Document { get; set; }
    }
}
