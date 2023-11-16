using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    public class IdentificationInfo : BaseObject
    {
        public IdentificationInfo(Session session) : base(session)
        {
        }

        [Persistent("person_oid")]
        public long PersonOid { get; set; }

        [Persistent("identification_number")]
        public string IdentificationNumber { get; set; }

        [Persistent("identification_serail_number")]
        public string SerialNumber { get; set; }

        [Persistent("validaty_date")]
        public DateTime ValidatyDate { get; set; }

        [Persistent("file_oid")]
        public long FileOid { get; set; }

        [Persistent("last_info")]
        public bool LastInfo { get; set; }
    }
}
