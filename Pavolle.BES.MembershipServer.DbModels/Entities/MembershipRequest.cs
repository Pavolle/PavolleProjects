using DevExpress.Xpo;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.MembershipServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MembershipServer.DbModels.Entities
{
    [Persistent("membership_requests")]
    public class MembershipRequest : BaseObject
    {
        public MembershipRequest(Session session) : base(session)
        {
        }

        [Persistent("request_id")]
        public string RequestId { get; set; }


        [Persistent("app_type")]
        public EBesAppType BesAppType { get; set; }


        [Persistent("organization_name")]
        public string OrganizationName { get; set; }


        [Persistent("membership_request_type")]
        public EMembershipRequestType MembershipRequestType { get; set; }


        [Persistent("country_oid")]
        public long CountryOid { get; set; }


        [Persistent("responsible")]
        public string ResponsiblePerson { get; set; }


        [Persistent("email")]
        public string Email { get; set; }


        [Persistent("phone_number")]
        public string PhoneNumber { get; set; }


        [Persistent("status")]
        public EMembershipRequestStatus Status { get; set; }
    }
}
