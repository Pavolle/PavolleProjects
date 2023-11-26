using log4net;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.Business
{
    public class SurrveyServerStatusManager : Singleton<SurrveyServerStatusManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SurrveyServerStatusManager));
        private SurrveyServerStatusManager() { }

        public object GetServerSettings(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object GetServerStatus(IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }


        public void SetSettingServerConnectionStatus(bool status)
        {
        }
    }
}
