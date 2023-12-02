using Pavolle.BES.JobServer.Business.Scheduler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavolle.BES.JobServer.Business.Scheduler.AuthServerCleanSession
{
    public class AuthServerCleanSessionJob : ServiceJobBase<AuthServerCleanSessionJob>
    {
        private AuthServerCleanSessionJob()
        {
        }

        public override void Init()
        {
            Init(typeof(AuthServerCleanSessionJobExecute));
        }
    }
}
