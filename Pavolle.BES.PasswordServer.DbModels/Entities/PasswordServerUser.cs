using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("password_server_users")]
    public class PasswordServerUser : BaseObject
    {
        public PasswordServerUser(Session session) : base(session)
        {
        }

        [Persistent("user_oid")]
        public long UserOid { get; set; }

        [Persistent("status")]
        public EUserStatus Status { get; set; }
    }
}
