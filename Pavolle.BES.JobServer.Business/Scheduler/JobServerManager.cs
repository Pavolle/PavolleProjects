using log4net;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.Business.Scheduler
{
    public class JobServerManager : Singleton<JobServerManager>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(JobServerManager));
        private JobServerManager()
        {

        }

        public void StartSchedulerServer()
        {

            _log.Info("Jobs starting...");

            string kontrolKron = "*/2 * * * * ?";

            _log.Info("Job control cron: " + kontrolKron);

            JobControlManager.Instance.Init();

            JobControlManager.Instance.Start(kontrolKron);

            _log.Info("Job Started.");
        }
    }
}