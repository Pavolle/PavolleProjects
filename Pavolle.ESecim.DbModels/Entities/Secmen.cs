using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.ESecim.DbModels.Entities
{
    [Persistent("secmenler")]
    public class Secmen : BaseObject
    {
        public Secmen(Session session) : base(session)
        {
        }

        [Persistent("kimlik_no")]
        public string KimlikNo { get; set; }

        [Persistent("secim_oid")]
        public Secim Secim { get; set; }

        [Persistent("oy_kullanildi")]
        public bool OyKullanildi { get; set; }
    }
}
