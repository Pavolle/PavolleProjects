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

namespace Pavolle.BES.JobServer.Business
{
    public class JobManager:Singleton<JobManager>
    {

        List<JobViewData> _jobs;
        private JobManager() 
        {
            LoadJobs();
        }

        public void LoadJobs()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {

                _jobs = session.Query<Job>().Select(t => new JobViewData
                {
                    Oid=t.Oid,
                    Active = t.Active,
                    JobType = t.JobType,
                    Cron = t.Cron,
                    ReadableName=t.ReadableName,
                    LastRunTime=t.LastRunTime,
                }).ToList();
            }
        }



        public bool Run(long oid)
        {
            throw new NotImplementedException();
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
