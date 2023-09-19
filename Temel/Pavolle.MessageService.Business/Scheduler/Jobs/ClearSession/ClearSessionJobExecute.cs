using log4net;
using Pavolle.MessageService.Scheduler;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Scheduler.Jobs.ClearSession
{

    public sealed class ClearSessionJobExecute : ServiceJobExecuteBase
    {
        private static ILog log = LogManager.GetLogger(typeof(ClearSessionJobExecute));

        public override void ItemExecute(IJobExecutionContext context)
        {

            try
            {

                log.Debug("DeviceUpdate görevi başlatıldı.");

                log.Debug("DeviceUpdate görevi tamamalandı.");
            }
            catch (Exception ex)
            {

                log.Debug("DeviceUpdateJobExecute error: " + ex);
            }


        }
    }
}
