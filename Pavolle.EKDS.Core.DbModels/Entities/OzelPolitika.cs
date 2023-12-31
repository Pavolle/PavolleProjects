using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.EKDS.Core.DbModels.Entities
{
    [Persistent("ozel_politikalar")]
    public class OzelPolitika : BaseObject
    {
        public OzelPolitika(Session session) : base(session)
        {
        }

        [Persistent("politika_oid")]
        public Politika Politika { get; set; }


        [Persistent("tckn")]
        public string Tckn { get; set; }
    }
}
