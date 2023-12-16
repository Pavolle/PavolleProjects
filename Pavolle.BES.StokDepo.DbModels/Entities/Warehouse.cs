using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.StokDepo.DbModels.Entities
{
    [Persistent("warehouse")]
    public class Warehouse : BaseObject
    {
        public Warehouse(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("name")]
        [Size(500)]
        public string Name { get; set; }

        [Persistent("code")]
        [Size(100)]
        public string Code { get; set; }

        [Persistent("definition")]
        [Size(1000)]
        public string Definition { get; set; }

        [Persistent("geolocation_oid")]
        public long GeolocationOid { get; set; }
    }
}
