using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.ESecim.DbModels.Entities
{
    public class Kullanici : BaseObject
    {
        public Kullanici(Session session) : base(session)
        {
        }

        public string KullaniciAdi { get; set; }

        public Firma Firma { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Telefon { get; set; }

        public string EPosta { get; set; }
    }
}
