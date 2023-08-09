using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PDKS.DbModels.Entities
{
    [Persistent("dogrulama_cihaz_tipleri")]
    public class DogrulamaCihazTipi : BaseObject
    {
        public DogrulamaCihazTipi(Session session) : base(session)
        {
        }

        [Persistent("tanim")]
        public string Tanim { get; set; }
    }
}
