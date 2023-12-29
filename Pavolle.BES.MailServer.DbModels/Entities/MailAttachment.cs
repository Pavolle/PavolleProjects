using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.DbModels.Entities
{
    [Persistent("mail_attachments")]
    public class MailAttachment : BaseObject
    {
        public MailAttachment(Session session) : base(session)
        {
        }

        [Persistent("mail_oid")]
        public Mail Mail { get; set; }

        [Persistent("path")]
        public string Path { get; set; }
    }
}
