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

        public string AppId { get; set; }
    }
}
