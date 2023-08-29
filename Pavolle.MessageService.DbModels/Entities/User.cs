using DevExpress.Xpo;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("users")]
    public class User : BaseObject
    {
        public User(Session session) : base(session)
        {
        }

        [Persistent("company_oid")]
        public Organization Company { get; set; }

        [Persistent("username")]
        [Size(50)]
        [Indexed(Name = "index_user_username", Unique = true)]
        public string Username { get; set; }

        [Persistent("kullanici_tipi")]
        public EUserType UserType { get; set; }

        [Persistent("ad")]
        [Size(50)]
        public string Name { get; set; }

        [Persistent("soyad")]
        [Size(50)]
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
