using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.ViewModels.Model
{
    public class AttachmentModel
    {
        public string FileName { get; set; }
        public byte[] Attachment { get; set; }
    }
}
