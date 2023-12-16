using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.StokDepo.DbModels.Entities
{
    [Persistent("stock")]
    public class Stock : BaseObject
    {
        public Stock(Session session) : base(session)
        {
        }

        [Persistent("cabinet_oid")]
        public Cabinet Cabinet { get; set; }

        [Persistent("product_oid")]
        public long ProductOid { get; set; }

        [Persistent("count")]
        public long Count { get; set; }
    }
}
