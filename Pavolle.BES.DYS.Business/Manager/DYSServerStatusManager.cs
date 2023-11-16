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
        private DYSServerStatusManager() { }

        public DYSSettingsResponse GetServerSettings(BesRequestBase request)
        {
            throw new NotImplementedException();
        }

        public DysStatusResponse GetServerStatus(BesRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
