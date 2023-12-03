using Pavolle.BES.JobServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.ViewModels.Response
{
    public class JobDetailResponse : ResponseBase
    {
        public JobDetailViewData Detail { get; set; }
    }
}
