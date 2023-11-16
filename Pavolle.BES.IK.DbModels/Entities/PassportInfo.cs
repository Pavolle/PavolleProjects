using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    [Persistent("passport_info")]
    public class PassportInfo : BaseObject
    {
        public PassportInfo(Session session) : base(session)
        {
        }

        [Persistent("person_oid")]
        public long PersonOid { get; set; }

        [Persistent("passport_number")]
        public string PassportNumber { get; set; }

        [Persistent("passport_file_oid")]
        public long? PassportFileOid { get; set; } //dys den sorgulanabilecek

        [Persistent("passport_validity_date")]
        public DateTime PassportValidityDate { get; set; }

        [Persistent("file_oid")]
        public long FileOid { get; set; }

        [Persistent("last_info")]
        public bool LastInfo { get; set; }
    }
}
