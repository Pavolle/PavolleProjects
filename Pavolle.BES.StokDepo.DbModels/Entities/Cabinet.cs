using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.StokDepo.DbModels.Entities
{
    public class Cabinet : BaseObject
    {
        public Cabinet(Session session) : base(session)
        {
        }

        [Persistent("warehouse_section_oid")]
        public WarehouseSection WarehouseSection { get; set; }

        [Persistent("name")]
        [Size(500)]
        public string Name { get; set; }

        [Persistent("code")]
        [Size(100)]
        public string Code { get; set; }
    }
}
