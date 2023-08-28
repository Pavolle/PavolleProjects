using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("authorizations")]
    public class Auth : BaseObject
    {

        public Auth(Session session) : base(session)
        {
        }

        [Persistent("api_key")]
        [Size(255)]
        public string ApiKey { get; set; }

        [Persistent("api_definition")]
        [Size(255)]
        public string ApiDefinition { get; set; }

        [Persistent("systemadmin_auth")]
        public string SystemAdminAuth { get; set; }

        [Persistent("admin_auth")]
        public string AdminAuth { get; set; }

        [Persistent("companyadmin_auth")]
        public string CompanyAdminAuth { get; set; }

        [Persistent("editable")]
        public bool Editable { get; set; }

        [Persistent("Anonymous")]
        public bool Anonymous { get; set; }
    }
}
