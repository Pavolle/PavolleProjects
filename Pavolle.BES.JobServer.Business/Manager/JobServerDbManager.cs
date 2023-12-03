using log4net;
using Pavolle.BES.JobServer.DbModels;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.Business.Manager
{
    public class JobServerDbManager : Singleton<JobServerDbManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(JobServerDbManager));

        public string _connectionString;
        private JobServerDbManager()
        {

        }

        public bool InitializeDb(string connectionString)
        {
            try
            {
                _connectionString = connectionString;
                _log.Info("Connecting to DB...");
                JobServerXpoManager.Instance.InitXpo(connectionString);
                _log.Info("Connected to DB successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Db connection error: Detail: " + ex);
                return false;
            }
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
