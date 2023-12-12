using Pavolle.BES.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Criteria
{
    public class ApiServiceCriteria : IntegrationAppRequestBase
    {
        public EBesAppType? AppType { get; set; }
    }
}
