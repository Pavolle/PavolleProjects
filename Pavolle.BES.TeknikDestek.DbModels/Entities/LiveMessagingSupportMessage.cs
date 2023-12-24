using DevExpress.Xpo;
using Pavolle.BES.TeknikDestek.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TeknikDestek.DbModels.Entities
{
    [Persistent("live_messaging_support_message")]
    public class LiveMessagingSupportMessage : BaseObject
    {
        public LiveMessagingSupportMessage(Session session) : base(session)
        {
        }

        [Persistent("live_messaging_support_oid")]
        public LiveMessagingSupport LiveMessagingSupport { get; set; }

        [Persistent("message")]
        [Size(1000)]
        public string Message { get; set; }

        [Persistent("live_message_direction")]
        public ELiveMessageDirection LiveMessageDirection { get; set; }

        [Persistent("order")]
        public long Order { get; set; }
    }
}
