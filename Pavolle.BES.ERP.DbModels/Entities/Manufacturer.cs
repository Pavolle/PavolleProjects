using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ERP.DbModels.Entities
{
    [Persistent("Manufacturers")]
    public class Manufacturer : BaseObject
    {
        public Manufacturer(Session session) : base(session)
        {
        }
    }
}
