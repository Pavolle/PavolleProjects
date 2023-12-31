using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.EKDS.Core.DbModels.Entities
{
    [Persistent("politika")]
    public class Politika : BaseObject
    {
        public Politika(Session session) : base(session)
        {
        }
    }
}
