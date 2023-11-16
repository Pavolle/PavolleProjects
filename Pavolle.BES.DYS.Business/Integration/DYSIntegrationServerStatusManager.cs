using Pavolle.BES.DYS.Business.Manager;
using Pavolle.BES.DYS.ViewModels.Integration.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Business.Integration
{
    public class DYSIntegrationServerStatusManager : Singleton<DYSIntegrationServerStatusManager>
    {
        public DYSSettingsResponse GetServerSettings(DYSIntegrationRequestBase request)
        {
            throw new NotImplementedException();
        }

        public DysStatusResponse GetServerStatus(DYSIntegrationRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
