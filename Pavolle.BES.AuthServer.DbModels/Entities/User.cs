using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("users")]
    public class User : BaseObject
    {
        public User(Session session) : base(session)
        {
        }

        [Persistent("username")]
        [Size(50)]
        [Indexed(Name = "index_users_username", Unique = true)]
        public string Username { get; set; }

        [Persistent("password")]
        [Size(1000)]
        public string Password { get; set; }

        [Persistent("person_oid")]
        public Person Person { get; set; }

        [Persistent("reset_password_code")]
        public string ResetPasswordCode { get; set; }

        [Persistent("wrong_try_count")]
        public int WrongTryCount { get; set; }

        [Persistent("is_locked")]
        public bool IsLocked { get; set; }

        [Persistent("locked_time")]
        public DateTime LockedTime { get; set; }

        [Persistent("is_blocked")]
        public bool Blocked { get; set; }

        [Persistent("blocked_time")]
        public DateTime BlockedTime { get; set; }

        [Persistent("status")]
        public EUserStatus Status { get; set; }

    }
}
