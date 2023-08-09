using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("authorizations")]
    public class Auth : BaseObject
    {
        public Auth(Session session) : base(session)
        {
        }

        [Persistent("api_key")]
        public string ApiKey { get; set; }

        [Persistent("api_definition")]
        public string ApiDefinition { get; set; }

        [Persistent("admin_auth")]
        public bool AdminAuth { get; set; }

        [Persistent("company_admin_auth")]
        public bool CompanyAdminAuth { get; set; }

        [Persistent("company_user_auth")]
        public bool CompanyUserAuth { get; set; }

        [Persistent("project_manager_auth")]
        public bool ProjectManagerAuth { get; set; }

        [Persistent("editable")]
        public bool Editable { get; set; }

    }
}
