using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ERP.DbModels.Entities
{
    [Persistent("manufacturers")]
    public class Manufacturer : BaseObject
    {
        public Manufacturer(Session session) : base(session)
        {
        }

        public string Name { get; set; }
        public long CountryOid { get; set; }
    }
}
