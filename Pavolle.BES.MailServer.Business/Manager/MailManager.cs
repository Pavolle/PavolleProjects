using Pavolle.BES.MailServer.Business.Manager.Integration;
using Pavolle.BES.MailServer.Business.Manager.Integration.PavolleMailServer;
using Pavolle.BES.MailServer.ViewModels.Model;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.Business.Manager
{
    public class MailManager : Singleton<MailManager>, IMailServerIntegrationManager
    {
        EMailServerIntegration _currentIntegration = EMailServerIntegration.PavolleMailServer;
        ConcurrentDictionary<EMailServerIntegration, IMailServerIntegrationManager> _integrations =new ConcurrentDictionary<EMailServerIntegration, IMailServerIntegrationManager> { };
        private MailManager() 
        { 
            _integrations.Clear();
            _integrations.TryAdd(EMailServerIntegration.PavolleMailServer, PavolleMailServerManager.Instance);
        }

        public void Initialize()
        {
            _currentIntegration = SettingServiceManager.Instance.GetCurrentMailServerIntegration();
            _integrations[_currentIntegration].Initialize();
        }

        public void SendMail(List<string> mailTo, List<string> mailInfo, string header, string htmlContent, List<AttachmentModel> attachments)
        {
            _integrations[_currentIntegration].SendMail(mailTo, mailInfo, header, htmlContent, attachments);
        }
    }
}
