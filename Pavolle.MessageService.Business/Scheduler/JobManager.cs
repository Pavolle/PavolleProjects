using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pavolle.MessageService.Scheduler
{
    public class JobManager:Singleton<JobManager>
    {
        //todo bu kısım üst katmana aktarılacak...
        List<JobViewData> _jobs;
        private JobManager() 
        {
            LoadJobs();
        }

        public void LoadJobs()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                _jobs = session.Query<Job>().Where(t => t.Active).Select(t => new JobViewData
                {
                    Oid=t.Oid,
                    Active = t.Active,
                    JobType = t.JobType,
                    Cron = t.Cron,
                    ReadableName=t.Name,
                    LastRunTime=t.LastRunTime,
                }).ToList();
            }
        }

        internal JobListResponse GetList()
        {
            try
            {
                return new JobListResponse
                {
                    DataList = _jobs
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
