using DevExpress.Xpo;
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
    }
}
