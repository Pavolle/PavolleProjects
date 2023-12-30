using DevExpress.Xpo;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.SettingServer.Common.Enums;
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

        [Persistent("bes_app_type")]
        public EBesAppType BesAppType { get; set; }

        [Persistent("mail_server_integration")]
        public EMailServerIntegration MailServerIntegration { get; set; }

        [Persistent("header")]
        [Size(1000)]
        public string Header { get; set; }

        [Persistent("content")]
        [Size(2000)]
        public string Content { get; set; }

        [Persistent("mail_to")]
        [Size(1000)]
        public string MailTo { get; set; }

        [Persistent("mail_info")]
        [Size(1000)]
        public string MailInfo { get; set; }

        [Persistent("send_status")]
        public bool SendStatus { get; set; }
    }
}
