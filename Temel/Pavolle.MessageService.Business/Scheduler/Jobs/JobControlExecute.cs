using log4net;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Scheduler;
using Quartz;

namespace Pavolle.MessageService.Business.Scheduler.Jobs
{
    public sealed class JobControlExecute : ServiceJobExecuteBase
    {
        private static ILog log = LogManager.GetLogger(typeof(JobControlExecute));

        public override void ItemExecute(IJobExecutionContext context)
        {
            try
            {
                var response = JobManager.Instance.GetList();

                if (response != null)
                {
                    foreach (var gorev in response.DataList)
                    {
                        IServiceJobBase job = JobControlManager.Instance.GetJob(gorev.JobType);

                        if (job != null)
                        {
                            if (gorev.Active)
                            {
                                if (job.JobStatus == EJobStatus.Start || job.JobStatus == EJobStatus.Stopped)
                                {
                                    job.Start(gorev.Cron);
                                }
                                else if (job.JobStatus == EJobStatus.Paused)
                                {
                                    job.Resume();

                                }
                                else if ((job.JobStatus == EJobStatus.Resumed || job.JobStatus == EJobStatus.Started) &&
                                         job.CronExpression != gorev.Cron)
                                {
                                    job.Rescheduler(gorev.Cron);
                                }
                            }
                            else
                            {
                                if (job.JobStatus == EJobStatus.Resumed || job.JobStatus == EJobStatus.Started)
                                {
                                    job.Pause();
                                }
                            }
                        }
                        else
                        {
                        }
                    }

                    foreach (
                        var stokServiceJobBase in
                            JobControlManager.Instance.RegisteredJobs.Where(
                                s =>
                                response.DataList.All(
                                    z => z.JobType != s.Key)))
                    {
                        if (stokServiceJobBase.Value.JobStatus == EJobStatus.Started ||
                            stokServiceJobBase.Value.JobStatus == EJobStatus.Resumed)
                        {
                            stokServiceJobBase.Value.Pause();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JobControlManager.Instance.Stop();
                log.Error("Bilinmeyen bir hata oluştu", ex);
            }
        }
    }
}
