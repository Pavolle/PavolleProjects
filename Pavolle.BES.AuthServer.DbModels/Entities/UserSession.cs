using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("user_sessions")]
    public class UserSession : BaseObject
    {
        public UserSession(Session session) : base(session)
        {
        }

        [Persistent("app_id")]
        public string AppId { get; set; }

        [Persistent("token")]
        [Size(1000)]
        public string Token { get; set; }

        [Persistent("is_valid")]
        public bool IsValid { get; set; }
    }
}
