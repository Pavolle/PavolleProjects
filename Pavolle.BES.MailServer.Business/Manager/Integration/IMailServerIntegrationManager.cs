using Pavolle.BES.MailServer.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.Business.Manager.Integration
{
    public interface IMailServerIntegrationManager
    {
        void Initialize();

        void SendMail(List<string> mailTo, List<string> mailInfo, string header, string htmlContent, List<AttachmentModel> attachments);
    }
}
