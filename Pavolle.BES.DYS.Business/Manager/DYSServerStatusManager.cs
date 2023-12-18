using log4net;
using Pavolle.BES.DYS.Business.Integration;
using Pavolle.BES.DYS.ViewModels.Integration.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Business.Manager
{
    public class DYSServerStatusManager : Singleton<DYSServerStatusManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(DYSServerStatusManager));
        private DYSServerStatusManager() { }

        public DYSSettingsResponse GetServerSettings(BesRequestBase request)
        {
            //Check request base;
            return DYSIntegrationServerStatusManager.Instance.GetServerSettings(new DYSIntegrationRequestBase { RequestIp=request.RequestIp });
        }

        public DysStatusResponse GetServerStatus(BesRequestBase request)
        {
            //Check request base;
            return DYSIntegrationServerStatusManager.Instance.GetServerStatus(new DYSIntegrationRequestBase { RequestIp = request.RequestIp });
        }
    }
}
