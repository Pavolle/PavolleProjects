using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TeknikDestek.DbModels.Entities.LiveSupport
{
    //Konu başlığı
    [Persistent("live_messaging_support_topic_categories")]
    public class LiveMessagingSupportTopicCategory : BaseObject
    {
        public LiveMessagingSupportTopicCategory(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("definition_td_oid")]
        public long DefinitionTDOid { get; set; }
    }
}
