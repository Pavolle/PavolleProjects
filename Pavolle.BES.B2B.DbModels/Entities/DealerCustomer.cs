using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.B2B.DbModels.Entities
{
    [Persistent("b2b_dealer_customer")]
    public class DealerCustomer : BaseObject
    {
        public DealerCustomer(Session session) : base(session)
        {
        }

        [Persistent("dealer_oid")]
        public Dealer Dealer { get; set; }
        public long PersonOid { get; set; }
    }
}
