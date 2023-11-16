using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    public class Employee : BaseObject
    {
        public Employee(Session session) : base(session)
        {
        }

        [Persistent("person_oid")]
        public long PersoneOid { get; set; }

        [Persistent("birthday")]
        public DateTime? Birthday { get; set; }

        [Persistent("started_date")]
        public DateTime StartingDate { get; set; }

        [Persistent("leave_date")]
        public DateTime? LeaveDate { get; set; }

        [Persistent("leave_reason_comment")]
        public string LeaveReasonComment { get; set; }
    }
}
