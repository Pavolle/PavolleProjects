using DevExpress.Xpo;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TeknikDestek.DbModels.Entities.LiveSupport
{
    [Persistent("live_messaging_support_user_language")]
    public class LiveMessagingSupportUserLanguage : BaseObject
    {
        public LiveMessagingSupportUserLanguage(Session session) : base(session)
        {
        }

        [Persistent("live_support_user_oid")]
        public LiveMessagingSupportUser LiveSupportUser { get; set; }

        [Persistent("language")]
        public ELanguage Language { get; set; }

        [Persistent("can_serve")]
        public bool CanServe { get; set; }
    }
}
