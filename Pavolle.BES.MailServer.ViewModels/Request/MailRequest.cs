using Pavolle.BES.MailServer.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.ViewModels.Request
{
    public class MailRequest
    {
        public List<string> MailTo { get; set; }
        public List<string> MailInfo { get; set; }
        public string Header { get; set; }
        public string HtmlContent { get; set; }
        public List<AttachmentModel> Attachments { get; set; }
    }
}
