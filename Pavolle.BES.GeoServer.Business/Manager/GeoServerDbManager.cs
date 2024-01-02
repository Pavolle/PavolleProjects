using log4net;
using Pavolle.BES.GeoServer.DbModels;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class GeoServerDbManager : Singleton<GeoServerDbManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(GeoServerDbManager));

        public string _connectionString;
        private GeoServerDbManager()
        {

        }

        public bool InitializeDb(string connectionString)
        {
            try
            {
                _connectionString = connectionString;
                _log.Info("Connecting to DB...");
                GeoServerXpoManager.Instance.InitXpo(connectionString);
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
