using log4net;
using Pavolle.BES.SettingServer.DbModels;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Business
{
    public class DbManager : Singleton<DbManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(DbManager));

        public string _connectionString;
        private DbManager()
        {

        }

        public bool InitializeDb(string connectionString)
        {
            try
            {
                _connectionString = connectionString;
                _log.Info("Veritabanı bağlantısı yapılıyor...");
                XpoManager.Instance.InitXpo(connectionString);
                _log.Info("Veritabanı bağlantısı sağlandı...");
                return true;
            }
            catch (Exception ex)
            {
                _log.Error("Veritabanına bağlanırken beklenmedik hata oluştu: Hata: " + ex);
                return false;
            }
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
