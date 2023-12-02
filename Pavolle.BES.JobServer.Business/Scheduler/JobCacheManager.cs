using DevExpress.Xpo;
using Pavolle.BES.JobServer.DbModels.Entities;
using Pavolle.BES.JobServer.ViewModels.ViewData;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pavolle.BES.JobServer.DbModels;
using Pavolle.BES.JobServer.ViewModels.Response;
using Pavolle.BES.Common.Enums;

namespace Pavolle.BES.JobServer.Business.Scheduler
{
    public class JobCacheManager : Singleton<JobCacheManager>
    {

        List<JobViewData> _jobs;
        private JobCacheManager()
        {
            LoadJobs();
        }

        public JobViewData? GetJobDetail(EBesJobType besJobType)
        {
            return _jobs.FirstOrDefault(t => t.JobType == besJobType);
        }

        public void LoadJobs()
        {
            using (Session session = JobServerXpoManager.Instance.GetNewSession())
            {
                _jobs = session.Query<Job>().Select(t => new JobViewData
                {
                    Oid = t.Oid,
                    BesAppType = t.BesAppType,
                    RunServiceUrl = t.RunServiceUrl,
                    Active = t.Active,
                    JobType = t.JobType,
                    Cron = t.Cron,
                    ReadableName = t.ReadableName,
                    LastRunTime = t.LastRunTime,
                    MailTo=t.MailTo,
                    SendMailAfterRun=t.SendMailAfterRun,
                    SMSTo=t.SMSTo,
                    SendSMSAfterRun=t.SendSMSAfterRun,
                }).ToList();
            }
        }

        public JobListResponse GetList()
        {
            return new JobListResponse
            {
                DataList = _jobs
            };
        }
    }
}
