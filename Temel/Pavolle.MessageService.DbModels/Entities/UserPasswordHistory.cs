using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("user_password_history")]
    public class UserPasswordHistory : BaseObject
    {
        public UserPasswordHistory(Session session) : base(session)
        {
        }

        [Persistent("user_oid")]
        public User User { get; set; }

        [Persistent("password")]
        [Size(1000)]
        public string Password { get; set; }
    }
}
