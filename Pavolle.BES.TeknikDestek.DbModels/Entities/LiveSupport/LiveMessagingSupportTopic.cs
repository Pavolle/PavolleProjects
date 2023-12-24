using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TeknikDestek.DbModels.Entities.LiveSupport
{
    [Persistent("live_mesagging_support_topics")]
    public class LiveMessagingSupportTopic : BaseObject
    {
        public LiveMessagingSupportTopic(Session session) : base(session)
        {
        }

        [Persistent("category_oid")]
        public LiveMessagingSupportTopicCategory Category { get; set; }


        [Persistent("definition_td_oid")]
        public long DefinitionTDOid { get; set; }
    }
}
