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
        [Size(255)]
        public string ApiKey { get; set; }

        [Persistent("api_definition")]
        [Size(255)]
        public string ApiDefinition { get; set; }

        [Persistent("admin_auth")]
        public bool AdminAuth { get; set; }

        [Persistent("company_admin_auth")]
        public bool CompanyAdminAuth { get; set; }

        [Persistent("company_user_auth")]
        public bool ProjectManagerAuth { get; set; }

        [Persistent("developer_auth")]
        public bool DeveloperAuth { get; set; }

        [Persistent("tecnical_support_specialist_auth")]
        public bool TecnicalSupportSpecialistAuth { get; set; }

        [Persistent("live_support_specialist_auth")]
        public bool LiveSupportSpecialistAuth { get; set; }

        [Persistent("editable")]
        public bool Editable { get; set; }

        [Persistent("Anonymous")]
        public bool Anonymous { get; set; }
    }
}
