using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.Business.Manager
{
    public class TranslateStatusManager : Singleton<TranslateStatusManager>
    {
        private TranslateStatusManager() { }

        public TranslateServerSettingsResponse GetServerSettings(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public TranslateServerStatusResponse GetServerStatus(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public void SetDbStatus(bool dbStatus)
        {
            throw new NotImplementedException();
        }

        public void SetSettingServerConnectionStatus(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
