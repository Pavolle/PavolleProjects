using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.EKDS.Core.DbModels.Entities
{
    [Persistent("kec_status_log")]
    public class KecStatusLog : BaseObject
    {
        public KecStatusLog(Session session) : base(session)
        {
        }

        [Persistent("kec_oid")]
        public Kec Kec { get; set; }
    }
}
