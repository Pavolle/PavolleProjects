using DevExpress.Xpo;
using Pavolle.Supplera.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Supplera.DbModels.Entities
{
    [Persistent("uyelik_basvurulari")]
    public class UyelikBasvuru : BaseObject
    {
        public UyelikBasvuru(Session session) : base(session)
        {
        }

        
        /*
        Bir kullanıcı üyelik başvurusu yaptığında onun için bir referans numarası üreteceğiz.
        Bu referans numarasını cache yazacağız. 
        Kullanıcı sisteme girdiği anda üye değilse ve üyelik başvurusunda bulunmuşsa başvuru durumu ile ilgili onu bilgilendireceğiz.
         */

        [Persistent("referans_numarasi")]
        public string ReferansNumarasi { get; set; }

        [Persistent("ad_soyad")]
        public string AdSoyad { get; set; }

        [Persistent("uyelik_basvuru_tipi")]
        public EUyelikBasvuruTipi UyelikBasvuruTipi { get; set; }

        //Bunu sadece kurumsal başvuru süreçlerinde yapacağız.
        [Persistent("kurum_adi")]
        public string KurumAdi { get; set; }

        [Persistent("telefon")]
        public string Telefon { get; set; }

        [Persistent("eposta")]
        public string Eposta { get; set; }

        [Persistent("ozel_mesaj")]
        [Size(2000)]
        public string OzelMesaj { get; set; }
    }
}
