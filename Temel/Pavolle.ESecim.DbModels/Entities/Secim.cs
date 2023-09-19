using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.ESecim.DbModels.Entities
{
    [Persistent("secimler")]
    public class Secim : BaseObject
    {
        public Secim(Session session) : base(session)
        {
        }

        [Persistent("firma_oid")]
        public Firma Firma { get; set; }

        [Persistent("baslik")]
        public string Baslik { get; set; }

        [Persistent("baslangic_tarihi")]
        public string BaslangicTarihi { get; set; }

        [Persistent("bitis_tarihi")]
        public string BitisTarihi { get; set; }
    }
}
