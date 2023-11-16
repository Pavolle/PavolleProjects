using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    //Kurulumda merkez ofis tanımlanacak
    [Persistent("branches")]
    public class Branch : BaseObject
    {
        public Branch(Session session) : base(session)
        {
        }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("head_office")]
        public bool HeadOffice { get; set; }

        [Persistent("parent_branch")]
        public Branch ParentBranch { get; set; }
    }
}
