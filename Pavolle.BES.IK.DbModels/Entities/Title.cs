using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    //Her title otomatik bir user group oluşturacak.
    [Persistent("titles")]
    public class Title : BaseObject
    {
        public Title(Session session) : base(session)
        {
        }

        [Persistent("deparment_oid")]
        public Department Department { get; set; }


        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("user_group_oid")]
        public long UserGroupOid { get; set; }
    }
}
