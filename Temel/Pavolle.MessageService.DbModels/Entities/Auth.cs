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

        [Persistent("api_service_oid")]
        public ApiService ApiService { get; set; }

        [Persistent("user_group_oid")]
        public UserGroup UserGroup { get; set; }

        [Persistent("is_authority")]
        public bool IsAuhtority { get; set; }
    }
}
