using DevExpress.Xpo;
using Pavolle.BES.TeknikDestek.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TeknikDestek.DbModels.Entities
{
    [Persistent("live_messaging_support")]
    public class LiveMessagingSupport : BaseObject
    {
        public LiveMessagingSupport(Session session) : base(session)
        {
        }

        [Persistent("technical_support_record_oid")]
        public TechnicalSupportRecord TechnicalSupportRecord { get; set; }


        [Persistent("status")]
        public ELiveMessagingSupportStatus Status { get; set; }


        [Persistent("service_requester_person_oid")]
        public long ServiceRequesterPersonOid { get; set; }


        [Persistent("service_provider_user_oid")]
        public long ServiceProviderUserOid { get; set; }


        [Persistent("start_time")]
        public DateTime StartTime { get; set; }


        [Persistent("end_time")]
        public DateTime? EndTime { get; set; }


        [Persistent("conclusion_reason")]
        public ELiveMessagingSupportConclusionReason ConclusionReason { get; set; }

    }
}
