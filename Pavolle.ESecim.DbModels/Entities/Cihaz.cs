using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.ESecim.DbModels.Entities
{
    [Persistent("cihazlar")]
    public class Cihaz : BaseObject
    {
        public Cihaz(Session session) : base(session)
        {
        }

        [Persistent("cihaz_id")]
        public long CihazId { get; set; }

        [Persistent("kec_id")]
        public long KecId { get; set; }

        [Persistent("anahtar")]
        public string Anahtar { get; set; }

        [Persistent("yazilim_versiyonu")]
        public string YazilimVersiyonu { get; set; }

        [Persistent("ip")]
        public string Ip { get; set; }
    }
}
