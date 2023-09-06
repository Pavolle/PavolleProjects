using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Business.Scheduler.Jobs;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Scheduler.Jobs.ClearSession
{
    public class ClearSessionJobManager : Singleton<ClearSessionJobManager>, IRunnableJobManager
    {
        private ClearSessionJobManager()
        {

        }

        public bool RunJob(EJobType jobType)
        {
            bool success = true;
            try
            {
            }
            catch (Exception ex)
            {
                success = false;
            }
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                //DeviceManager.Instance.CheckConnection();

                var job = session.Query<Job>().FirstOrDefault(t => t.JobType == jobType);
                job.LastRunTime = DateTime.Now;
                job.Save();

                new JobRunLog(session)
                {
                    Job = job,
                    Success = success,
                    Result = "Done",//TODO Detaylandırılacak
                }.Save();
            }

            return success;
        }
    }
}
