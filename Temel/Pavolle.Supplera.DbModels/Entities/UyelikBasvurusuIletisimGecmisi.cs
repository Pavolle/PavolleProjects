using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.Supplera.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Supplera.DbModels.Entities
{
    [Persistent("uyelik_basvurusu_iletisim_gecmisi")]
    public class UyelikBasvurusuIletisimGecmisi : BaseObject
    {
        public UyelikBasvurusuIletisimGecmisi(Session session) : base(session)
        {
        }

        [Persistent("iletisim_yonu")]
        public EUyelikBasvurusuIletisimYonu IletisimYonu { get; set; }

        [Persistent("kullanici_adi")]
        public Kullanici Kullanici { get; set; }

        [Persistent("uyelik_basvurusu")]
        public UyelikBasvuru UyelikBasvurusu { get; set; }

        [Persistent("mesaj")]
        [Size(2000)]
        public string Mesaj { get; set; }
    }
}
