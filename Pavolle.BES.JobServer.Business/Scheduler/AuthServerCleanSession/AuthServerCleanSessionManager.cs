using DevExpress.Xpo;
using log4net;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.JobServer.Business.Scheduler;
using Pavolle.Core.Utils;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pavolle.BES.JobServer.Business.Scheduler.AuthServerCleanSession
{
    public class AuthServerCleanSessionManager : Singleton<AuthServerCleanSessionManager>, IRunnableJobManager
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(AuthServerCleanSessionManager));
        private AuthServerCleanSessionManager()
        {

        }

        //TODO Burada cihaz o sırada kimlik doğrulama ve benzeri işlerle meşgulse kotnroller konusunda extra işlem yapmamız lazım
        public bool RunJob(EBesJobType jobType)
        {
            bool success = true;
            try
            {

            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }
    }
}
