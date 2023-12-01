using Pavolle.BES.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavolle.BES.JobServer.Business
{
    public interface IRunnableJobManager
    {
        bool RunJob(EBesJobType jobType);

    }
}
