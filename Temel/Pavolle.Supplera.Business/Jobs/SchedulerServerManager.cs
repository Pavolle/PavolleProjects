using log4net;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavolle.Supplera.Business.Jobs
{
    public class SchedulerServerManager:Singleton<SchedulerServerManager>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(SchedulerServerManager));
        private SchedulerServerManager()
        {

        }

        public void StartSchedulerServer(string kontrolKron)
        {

            _log.Info("Zamanlanmis görevler başlatılıyor...");

            if (string.IsNullOrEmpty(kontrolKron))
            {
                kontrolKron = "*/2 * * * * ?";
            }

            _log.Info("Zamanlanmış görev konrtrol cron: " + kontrolKron);

            JobControlManager.Instance.Init();

            JobControlManager.Instance.Start(kontrolKron);

            _log.Info("Zamanlanmış görevler başlatıldı.");
        }
    }
}
