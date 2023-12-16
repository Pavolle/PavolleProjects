using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("organizations")]
    public class Organization : BaseObject
    {
        public Organization(Session session) : base(session)
        {
        }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("code")]
        [Size(5)]
        public string Code { get; set; }

        [Persistent("zip_code")]
        public string ZipCode { get; set; }
    }
}
