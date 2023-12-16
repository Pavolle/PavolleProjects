using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.DbModels.Entities
{
    public class Mail : BaseObject
    {
        public Mail(Session session) : base(session)
        {
        }

        public string Header { get; set; }
        public string Content { get; set; }
        public bool HasAttacment { get; set; }
        public bool SendStatus { get; set; }
    }
}
