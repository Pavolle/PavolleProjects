using log4net;
using Pavolle.Core.Utils;
using Pavolle.MessageService.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class DbManager : Singleton<DbManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(DbManager));
        private DbManager()
        {
        }

        public bool Initialize(string connectionString)
        {
            try
            {
                XpoManager.Instance.InitXpo(connectionString);
                _log.Info("Database connection etablish.");
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Database connection error: " + ex);
                return false;
            }
        }
    }
}
