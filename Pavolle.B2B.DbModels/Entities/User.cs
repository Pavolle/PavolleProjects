using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("users")]
    public class User : BaseObject
    {

        public User(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public Organization Organization { get; set; }

        [Persistent("username")]
        [Size(50)]
        [Indexed(Name = "index_users_username", Unique = true)]
        public string Username { get; set; }

        [Persistent("user_type")]
        public EUserType UserType { get; set; }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("surname")]
        [Size(255)]
        public string Surname { get; set; }

        [Persistent("email")]
        [Size(255)]
        public string Email { get; set; }

        [Persistent("phone_number")]
        [Size(50)]
        public string PhoneNumber { get; set; }

        [Persistent("password")]
        [Size(1000)]
        public string Password { get; set; }

        [Persistent("wrong_try_count")]
        public int WrongTryCount { get; set; }

        [Persistent("is_locked")]
        public bool IsLocked { get; set; }
    }
}
