using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.Business.Manager
{
    public class MailServerStatusManager : Singleton<MailServerStatusManager>
    {
        private MailServerStatusManager() { }

        public object GetServerSettings(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object GetServerStatus(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
