using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    public class PhysicalFile : BaseObject
    {
        public PhysicalFile(Session session) : base(session)
        {
        }

        public string Code { get; set; }
        public bool HasProtection { get; set; }
    }
}
