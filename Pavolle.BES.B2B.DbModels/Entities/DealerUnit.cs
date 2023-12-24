using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.B2B.DbModels.Entities
{
    public class DealerUnit : BaseObject
    {
        public DealerUnit(Session session) : base(session)
        {
        }

        [Persistent("dealer_oid")]
        public Dealer Dealer { get; set; }

        [Persistent("warehouse_oid")]
        public long WarehouseOid { get; set; }
    }
}
