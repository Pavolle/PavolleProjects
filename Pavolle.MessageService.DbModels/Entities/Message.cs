using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    internal class Message : BaseObject
    {
        public Message(Session session) : base(session)
        {
        }

        public App Uygulama { get; set; }

        //Bu alanın da tekil olmasını kontrol edeceğiz.
        public string MesajId { get; set; }
        public string UserId { get; set; }
    }
}
