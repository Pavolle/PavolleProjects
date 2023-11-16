using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    [Persistent("departments")]
    public class Department : BaseObject
    {
        public Department(Session session) : base(session)
        {
        }

        [Persistent("branch_oid")]
        public Branch Branch { get; set; }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }
    }
}
