using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.CRM.DbModels.Entities
{
    [Persistent("b2b_pricing_periods")]
    public class PricingPeriod : BaseObject
    {
        public PricingPeriod(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("start_date")]
        public DateTime StartDate { get; set; }

        [Persistent("end_date")]
        public DateTime EndDate { get; set; }

        [Persistent("is_current_period")]
        public bool IsCurrentPeriod { get; set; }
    }
}
