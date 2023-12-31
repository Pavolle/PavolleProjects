using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.EKDS.Core.DbModels.Entities
{
    [Persistent("special_politika")]
    public class SpecialPolitika : BaseObject
    {
        public SpecialPolitika(Session session) : base(session)
        {
        }

        [Persistent("politika_oid")]
        public Politika Politika { get; set; }


        [Persistent("tckn")]
        public string Tckn { get; set; }
    }
}
