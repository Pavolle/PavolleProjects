using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.CRM.DbModels.Entities
{
    [Persistent("b2b_pricing_group")]
    public class PricingGroup : BaseObject
    {
        public PricingGroup(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("name")]
        public string Name { get; set; }
    }
}
