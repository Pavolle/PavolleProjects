using Pavolle.BES.JobServer.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavolle.BES.JobServer.Business.AuthServerCleanSession
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
