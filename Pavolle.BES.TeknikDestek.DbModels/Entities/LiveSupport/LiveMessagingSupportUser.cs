using DevExpress.Xpo;
using Pavolle.BES.TeknikDestek.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TeknikDestek.DbModels.Entities.LiveSupport
{
    [Persistent("live_messaging_support_users")]
    public class LiveMessagingSupportUser : BaseObject
    {
        public LiveMessagingSupportUser(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("user_oid")]
        public long UserOid { get; set; }

        [Persistent("waiting_service_requester_count")]
        public int WaitingServiceRequesterCount { get; set; }

        [Persistent("current_status")]
        public ELiveSupportUserCurrentStatus LiveSupportUserCurrentStatus { get; set; }
    }
}
