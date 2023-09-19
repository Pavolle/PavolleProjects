using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("user_groups")]
    public class UserGroup.cs : BaseObject
    {

        public UserGroup.cs(Session session) : base(session)
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
