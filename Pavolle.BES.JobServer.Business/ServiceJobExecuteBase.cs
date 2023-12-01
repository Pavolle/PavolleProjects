using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.Business
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
                log.Error("Bilinmeyen bir hata oluştu", ex);
            }
        }

        //Task<IJob> Execute(IJobExecutionContext context);
    }
}
