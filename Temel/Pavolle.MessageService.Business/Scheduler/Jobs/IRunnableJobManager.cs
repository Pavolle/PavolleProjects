using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.Business.Scheduler.Jobs
{
    public interface IRunnableJobManager
    {
        bool RunJob(EJobType jobType);
    }
}
