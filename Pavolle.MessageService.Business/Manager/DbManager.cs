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
    public class DbManager:Singleton<DbManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(DbManager));
        private DbManager()
        { 
        }

        public bool InitDatabase(string connectionString)
        {
            try
            {
                XpoManager.Instance.InitXpo(connectionString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
