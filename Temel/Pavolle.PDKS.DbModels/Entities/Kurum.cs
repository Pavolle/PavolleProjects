using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PDKS.DbModels.Entities
{
    public class Kurum:BaseObject
    {
        public Kurum(Session session) : base(session)
        {
        }

        public string Ad { get; set; }
    }
}
