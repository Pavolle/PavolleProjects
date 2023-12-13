using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.StokDepo.DbModels.Entities
{
    public class Unit : BaseObject
    {
        public Unit(Session session) : base(session)
        {
        }

        public long OrganizationOid { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
    }
}
