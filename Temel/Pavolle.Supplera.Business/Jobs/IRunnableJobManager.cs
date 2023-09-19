using Pavolle.Supplera.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavolle.Supplera.Business.Jobs
{
    public interface IRunnableJobManager
    {
        bool RunJob(EJobType jobType);

    }
}
