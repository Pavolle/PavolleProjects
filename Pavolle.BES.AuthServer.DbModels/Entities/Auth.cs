using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("authorizations")]
    public class Auth : BaseObject
    {
        public Auth(Session session) : base(session)
        {
        }

        [Persistent("api_service_oid")]
        public ApiService ApiService { get; set; }


        [Persistent("role_oid")]
        public Role Role { get; set; }


        [Persistent("is_authority")]
        public bool IsAuthority { get; set; }
    }
}
