using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("user_password_history")]
    public class UserPasswordHistory : BaseObject
    {
        public UserPasswordHistory(Session session) : base(session) {}

        [Persistent("user_oid")]
        public User User { get; set; }

        [Persistent("password")]
        [Size(1000)]
        public string Password { get; set; }

    }
}
