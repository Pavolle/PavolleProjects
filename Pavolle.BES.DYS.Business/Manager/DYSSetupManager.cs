using log4net;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Business.Manager
{
    public class DYSSetupManager : Singleton<DYSSetupManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(DYSSetupManager));
        private DYSSetupManager() { }

        public void Initialize()
        {

        }

        //ROOT folder elementi ve root klasörünün oluşturulması.
    }
}
