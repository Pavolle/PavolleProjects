using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ERP.DbModels.Entities
{
    [Persistent("product_group")]
    public class ProductGroup : BaseObject
    {
        public ProductGroup(Session session) : base(session)
        {
        }

        public ProductFamily ProductFamily { get; set; }
    }
}
