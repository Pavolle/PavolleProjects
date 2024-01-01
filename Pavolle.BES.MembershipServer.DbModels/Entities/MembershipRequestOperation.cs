using DevExpress.Xpo;
using Pavolle.BES.MembershipServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MembershipServer.DbModels.Entities
{
    public class MembershipRequestOperation : BaseObject
    {
        public MembershipRequestOperation(Session session) : base(session)
        {
        }

        [Persistent("membership_request_oid")]
        public MembershipRequest MembershipRequest { get; set; }


        [Persistent("old_status")]
        public EMembershipRequestStatus? OldStatus { get; set; }


        [Persistent("new_status")]
        public EMembershipRequestStatus NewStatus { get; set; }


        [Persistent("operation")]
        public EMembershipRequestOperation Operation { get; set; }


        [Persistent("user_oid")]
        public long? UserOid { get; set; }


        [Persistent("comment")]
        public string Comment { get; set; }
    }
}
