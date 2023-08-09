using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PDKS.DbModels.Entities
{
    public class GecisNoktasi:BaseObject
    {
        public GecisNoktasi(Session session) : base(session)
        {
        }

        public Kurum Kurum { get; set; }
    }
}
