using DevExpress.Xpo;
using Pavolle.PDKS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PDKS.DbModels.Entities
{
    //Bir 
    public class Kurulum:BaseObject
    {
        public Kurulum(Session session) : base(session)
        {
        }

        public DogrulamaCihazi DogrulamaCihazi { get; set; }
        public GecisNoktasi GecisNoktasi { get; set; }
        public EGecisYonu GecisYonu { get; set; }
    }
}
