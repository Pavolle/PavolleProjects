using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("user_groups")]
    public class Auth : BaseObject
    {

        public Auth(Session session) : base(session)
        {
        }

        [Persistent("api_service_oid")]
        public ApiService ApiService { get; set; }

        [Persistent("user_group_oid")]
        public UserGroup UserGroup { get; set; }

        [Persistent("is_authority")]
        public bool IsAuhtority { get; set; }
    }
}
