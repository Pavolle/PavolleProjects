using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("user_password_histories")]
    public class UserPasswordHistory : BaseObject
    {
        public UserPasswordHistory(Session session) : base(session)
        {
        }
    }
}
