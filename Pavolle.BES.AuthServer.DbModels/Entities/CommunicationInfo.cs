using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("as_communication_info")]
    public class CommunicationInfo : BaseObject
    {
        public CommunicationInfo(Session session) : base(session)
        {
        }

        [Persistent("person_oid")]
        public Person Person { get; set; }

        [Persistent("communication_type")]
        public ECommunicationType CommunicationType { get; set; }

        [Persistent("value")]
        [Size(500)]
        public string Value { get; set; }

        [Persistent("is_verified")]
        public bool IsVerified { get; set; }

        [Persistent("verify_code")]
        public string VerifyCode { get; set; }

        [Persistent("is_default")]
        public bool IsDefault { get; set; }
    }
}
