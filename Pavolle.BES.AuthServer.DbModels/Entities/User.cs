using DevExpress.Xpo;
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

        [Persistent("name")]
        public string Name { get; set; }

        [Persistent("surname")]
        public string Surname { get; set; }

        [Persistent("password")]
        [Size(1000)]
        public string Password { get; set; }
    }
}
