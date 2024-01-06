using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.NotificationServer.DbModels.Entities
{
    public class UserNotification : BaseObject
    {
        public UserNotification(Session session) : base(session)
        {
        }
    }
}
