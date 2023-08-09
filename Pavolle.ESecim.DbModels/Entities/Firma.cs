using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.ESecim.DbModels.Entities
{
    [Persistent("firmalar")]
    public class Firma : BaseObject
    {
        public Firma(Session session) : base(session)
        {
        }

        [Persistent("ad")]
        public string Ad { get; set; }



        [Persistent("logo_base64")]
        [Size(3000)]
        public string LogoBase64 { get; set; }
    }
}
