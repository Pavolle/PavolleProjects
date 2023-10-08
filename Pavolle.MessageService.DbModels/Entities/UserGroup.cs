using DevExpress.Xpo;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("user_groups")]
    public class UserGroup : BaseObject
    {
        public UserGroup(Session session) : base(session) {}

        [Persistent("organization_oid")]
        public Organization Organization { get; set; }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("user_type")]
        public EUserType UserType { get; set; }

    }
}
