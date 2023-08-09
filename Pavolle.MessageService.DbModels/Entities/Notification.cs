using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("notifications")]
    public class Notification : BaseObject
    {
        public Notification(Session session) : base(session)
        {
        }

        //Kullanıcı bazında oluşturulacak.
    }
}
