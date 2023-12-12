using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ERP.DbModels.Entities
{
    public class ProductProperty : BaseObject
    {
        public ProductProperty(Session session) : base(session)
        {
        }

        public Product Product { get; set; }

        public ProductGroupProperty ProductGroupProperty { get; set; }
        public bool CanUse { get; set; }
    }
}
