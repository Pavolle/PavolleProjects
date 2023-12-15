using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("physical_folder_access")]
    public class PhysicalFolderAccess : BaseObject
    {
        public PhysicalFolderAccess(Session session) : base(session)
        {
        }

        [Persistent("physical_folder_oid")]
        public PhysicalFolder PhysicalFolder { get; set; }

        [Persistent("person_oid")]
        public long? PersonOid { get; set; }

        [Persistent("has_access")]
        public bool HasAccess { get; set; }
    }
}
