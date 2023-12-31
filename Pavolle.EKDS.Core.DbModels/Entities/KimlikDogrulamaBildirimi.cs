using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.EKDS.Core.DbModels.Entities
{
    [Persistent("kimlik_dogrulama_bildirimleri")]
    public class KimlikDogrulamaBildirimi : BaseObject
    {
        public KimlikDogrulamaBildirimi(Session session) : base(session)
        {
        }

        [Persistent("tckn")]
        public string Tckn { get; set; }


        [Persistent("kdb")]
        public byte[] Kdb { get; set; }


        [Persistent("kdbo")]
        public byte[] Kdbo { get; set; }


        [Persistent("dogrulama_zamani")]
        public DateTime? DogrulamaZamani { get; set; }


        [Persistent("bildirim_zamani")]
        public DateTime? BidirimZamani { get; set; }
    }
}
