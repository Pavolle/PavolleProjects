using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ERP.DbModels.Entities
{
    [Persistent("product_family")]
    public class ProductFamily : BaseObject
    {
        public ProductFamily(Session session) : base(session)
        {
        }

        public long? OrganizationOid { get; set; }
    }
}
