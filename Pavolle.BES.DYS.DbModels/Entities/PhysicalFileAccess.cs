using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("physical_file_access")]
    public class PhysicalFileAccess : BaseObject
    {
        public PhysicalFileAccess(Session session) : base(session)
        {
        }

        [Persistent("physical_file_oid")]
        public PhysicalFile PhysicalFile { get; set; }

        [Persistent("person_oid")]
        public long? PersonOid { get; set; }

        [Persistent("has_access")]
        public bool HasAccess { get; set; }
    }
}
