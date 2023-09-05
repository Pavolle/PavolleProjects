using log4net;
using Quartz;

namespace Pavolle.MessageService.Scheduler
{
    [DisallowConcurrentExecution]
    [PersistJobDataAfterExecution]
    public abstract class ServiceJobExecuteBase : IJob
    {
        private static ILog log = LogManager.GetLogger(typeof(ServiceJobExecuteBase));

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                ItemExecute(context);
            }
            catch (Exception ex)
            {
                log.Error("Bilinmeyen bir hata oluştu", ex);
            }
        }

        public abstract void ItemExecute(IJobExecutionContext context);

        async Task IJob.Execute(IJobExecutionContext context)
        {
            try
            {
                ItemExecute(context);
            }
            catch (Exception ex)
            {
                log.Error("Unexpected error occured: " + ex);
            }
        }
    }
}
