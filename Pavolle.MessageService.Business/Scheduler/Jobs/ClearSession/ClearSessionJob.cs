
using Pavolle.MessageService.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Scheduler.Jobs.ClearSession
{
    public class ClearSessionJob : ServiceJobBase<ClearSessionJob>
    {
        private ClearSessionJob()
        {
        }

        public override void Init()
        {
            Init(typeof(ClearSessionJobExecute));
        }
    }
}
