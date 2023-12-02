using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.ViewModels.Criteria
{
    public class ListJobCriteria : IntegrationAppRequestBase
    {
        public EBesAppType? BesAppType { get; set; }
    }
}
