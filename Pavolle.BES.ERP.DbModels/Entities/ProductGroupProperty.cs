using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ERP.DbModels.Entities
{
    [Persistent("erp_product_group_properties")]
    public class ProductGroupProperty : BaseObject
    {
        public ProductGroupProperty(Session session) : base(session)
        {
        }

        public ProductGroup ProductGroup { get; set; }
    }
}
