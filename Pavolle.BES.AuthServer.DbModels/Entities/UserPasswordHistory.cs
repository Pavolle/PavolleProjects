using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("as_user_password_histories")]
    public class UserPasswordHistory : BaseObject
    {
        public UserPasswordHistory(Session session) : base(session)
        {
        }

        [Persistent("user_oid")]
        public User User { get; set; }

        [Persistent("password")]
        public string Password { get; set; }

        [Persistent("change_time")]
        public DateTime ChangeTime { get; set; }
    }
}
