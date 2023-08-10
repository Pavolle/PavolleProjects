using DevExpress.Xpo;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("companies")]
    public class Company : BaseObject
    {
        public Company(Session session) : base(session)
        {
        }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("code")]
        public string Code { get; set; }

        [Persistent("address")]
        [Size(1000)]
        public string Address { get; set; }

        [Persistent("manager_company")]
        public bool Manager { get; set; }

        [Persistent("admin_user_oid")]
        public User AdminUser { get; set; }
    }
}
