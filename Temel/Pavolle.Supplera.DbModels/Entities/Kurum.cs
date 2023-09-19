using DevExpress.Xpo;
using Pavolle.Supplera.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Supplera.DbModels.Entities
{
    [Persistent("kurumlar")]
    public class Kurum : BaseObject
    {
        public Kurum(Session session) : base(session)
        {
        }


        [Persistent("uyelik_basvuru_oid")]
        public UyelikBasvuru UyelikBasvuru { get; set; }

        [Persistent("ad")]
        public string Ad { get; set; }

        [Persistent("adres")]
        public string Adres { get; set; }

        [Persistent("enlem")]
        public double? Enlem { get; set; }

        [Persistent("boylam")]
        public double? Boylam { get; set; }

        [Persistent("uyelik_durumu")]
        public EUyelikDurumu UyelikDurumu { get; set; }

        [Persistent("uyelik_baslangic_tarihi")]
        public DateTime UyelikBaslangicTarihi { get; set; }

        [Persistent("uyelik_yenilenme_tarihi")]
        public DateTime UyelikYenilenmeTarihi { get; set; }

        [Persistent("uyelik_bitis_tarihi")]
        public DateTime UyelikBitisTarihi { get; set; }
    }
}
