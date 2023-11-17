using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ViewModels.Request
{
    public class IntegrationAppRequestBase
    {
        public string RequestIp { get; set; }
        public string AppCode { get; set; }
        public string LogBase { get; set; }
        public string AppId { get; set; }
    }
}
