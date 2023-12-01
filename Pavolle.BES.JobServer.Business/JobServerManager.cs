using log4net;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.Business
{
    public class JobServerManager : Singleton<JobServerManager>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(JobServerManager));
        private JobServerManager()
        {

        }

        public void StartSchedulerServer()
        {

            _log.Info("Zamanlanmis görevler başlatılıyor...");

            string kontrolKron = "*/2 * * * * ?";

            _log.Info("Zamanlanmış görev konrtrol cron: " + kontrolKron);

            JobControlManager.Instance.Init();

            JobControlManager.Instance.Start(kontrolKron);

            _log.Info("Zamanlanmış görevler başlatıldı.");
        }
    }
}