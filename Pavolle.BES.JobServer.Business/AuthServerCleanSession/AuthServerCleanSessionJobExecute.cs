
using log4net;
using Pavolle.BES.Common.Enums;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pavolle.BES.JobServer.Business.AuthServerCleanSession
{
    public sealed class AuthServerCleanSessionJobExecute : ServiceJobExecuteBase
    {
        private static ILog log = LogManager.GetLogger(typeof(AuthServerCleanSessionJobExecute));

        public override void ItemExecute(IJobExecutionContext context)
        {
            try
            {
                log.Info("AuthServerCleanSession job starting...");
                AuthServerCleanSessionManager.Instance.RunJob(EBesJobType.AuthServerCleanSession);
                log.Info("AuthServerCleanSession job done...");
            }
            catch (Exception ex)
            {
                log.Debug("AuthServerCleanSession error: " + ex);
            }
        }
    }
}
