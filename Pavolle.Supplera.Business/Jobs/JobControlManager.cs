using log4net;
using Pavolle.Core.Enums;
using Pavolle.Supplera.Common.Enums;
using Quartz;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pavolle.Supplera.Business.Jobs
{
    public class JobControlManager : ServiceJobBase<JobControlManager>
    {
        private static ILog _log = LogManager.GetLogger(typeof(JobControlManager));
        private JobControlManager()
        {
        }

        public ConcurrentDictionary<EJobType, IServiceJobBase> RegisteredJobs = new ConcurrentDictionary<EJobType, IServiceJobBase>();

        public override void Start(string cronExpression, params KeyValuePair<string, object>[] parameters)
        {
            RegisteredJobs.Clear();

            //RegisterJob(EJobType.UyelikKontrol, HelloChainControlJob.Instance);


            base.Start(cronExpression, parameters);
            _log.Debug("JobControl görevi başlatıldı...");
        }

        public void Stop()
        {
            if (_scheduler == null) return;
            _scheduler.Shutdown(true);
            _jobStatus = EJobStatus.Stopped;

            _log.Info(string.Format("{0} durduruldu.", Name));
        }

        private void RegisterJob<T>(EJobType kod, ServiceJobBase<T> ins) where T : class
        {
            ins.Init();
            RegisteredJobs.TryAdd(kod, ins);
        }

        public override void Init()
        {
            //Init(typeof(JobControlExecute));
        }

        public IServiceJobBase GetJob(EJobType? kod)
        {
            return kod.HasValue && RegisteredJobs.ContainsKey(kod.Value) ? RegisteredJobs[kod.Value] : null;
        }
    }
    //public sealed class JobControlExecute : ServiceJobExecuteBase
    //{
    //    private static ILog log = LogManager.GetLogger(typeof(JobControlExecute));

    //    public override void ItemExecute(IJobExecutionContext context)
    //    {
    //        try
    //        {
    //            var response = JobManager.Instance.GetList();

    //            if (response != null)
    //            {
    //                foreach (var gorev in response.DataList)
    //                {
    //                    IServiceJobBase job = JobControlManager.Instance.GetJob(gorev.JobType);

    //                    if (job != null)
    //                    {
    //                        if (gorev.Active)
    //                        {
    //                            if (job.JobStatus == EJobStatus.Start || job.JobStatus == EJobStatus.Stopped)
    //                            {
    //                                job.Start(gorev.Cron);
    //                            }
    //                            else if (job.JobStatus == EJobStatus.Paused)
    //                            {
    //                                job.Resume();

    //                            }
    //                            else if ((job.JobStatus == EJobStatus.Resumed || job.JobStatus == EJobStatus.Started) &&
    //                                     job.CronExpression != gorev.Cron)
    //                            {
    //                                job.Rescheduler(gorev.Cron);
    //                            }
    //                        }
    //                        else
    //                        {
    //                            if (job.JobStatus == EJobStatus.Resumed || job.JobStatus == EJobStatus.Started)
    //                            {
    //                                job.Pause();
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                    }
    //                }

    //                foreach (
    //                    var stokServiceJobBase in
    //                        JobControlManager.Instance.RegisteredJobs.Where(
    //                            s =>
    //                            response.DataList.All(
    //                                z => z.JobType != s.Key)))
    //                {
    //                    if (stokServiceJobBase.Value.JobStatus == EJobStatus.Started ||
    //                        stokServiceJobBase.Value.JobStatus == EJobStatus.Resumed)
    //                    {
    //                        stokServiceJobBase.Value.Pause();
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            JobControlManager.Instance.Stop();
    //            log.Error("Bilinmeyen bir hata oluştu", ex);
    //        }
    //    }
    //}
}
