using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SetupApp
{
    public class SetupSettings 
    {
        public string DbConnection { get; set; }
        public string SystemAdminName { get; set; }
        public string SystemAdminPassword { get; set; }
        public bool AppServerSetupAuth { get; set; }
        public bool SurrveyServerSetupAuth { get; set; }
        public bool FirstPartnersSetupAuth { get; set; }
    }
}
