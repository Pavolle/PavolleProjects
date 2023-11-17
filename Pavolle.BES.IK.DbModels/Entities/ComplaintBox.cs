using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    [Persistent("complaint_boxs")]
    public class ComplaintBox : BaseObject
    {
        public ComplaintBox(Session session) : base(session)
        {
        }

        [Persistent("header")]
        public string Header { get; set; }

        [Persistent("content")]
        public string Content { get; set; }

        [Persistent("reason")]
        public string Reason { get; set; }

        [Persistent("suggestion")]
        public string Suggestion { get; set; }

        [Persistent("verified")]
        public bool Verified { get; set; }
    }
}
