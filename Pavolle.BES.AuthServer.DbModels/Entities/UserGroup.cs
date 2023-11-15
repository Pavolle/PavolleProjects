using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("user_groups")]
    public class UserGroup : BaseObject
    {

        public UserGroup(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public Organization Organization { get; set; }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("user_type")]
        public EUserType UserType { get; set; }
    }
}
