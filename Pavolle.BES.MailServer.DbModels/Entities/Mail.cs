using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.DbModels.Entities
{
    [Persistent("mails")]
    public class Mail : BaseObject
    {
        public Mail(Session session) : base(session)
        {
        }

        [Persistent("header")]
        public string Header { get; set; }

        [Persistent("content")]
        public string Content { get; set; }

        [Persistent("mail_to")]
        public string MailTo { get; set; }

        [Persistent("mail_info")]
        public string MailInfo { get; set; }

        [Persistent("send_status")]
        public bool SendStatus { get; set; }
    }
}
