using Pavolle.Core.Helper;
using Pavolle.Core.Utils;
using Pavolle.PassCross.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    public class DbManager : Singleton<DbManager>
    {
        SQLiteConnection _db;
        private DbManager()
        {

        }

        public SettingsDbModel InitilaizeDb(string appName)
        {
            _db = GetDb(appName);
            _db.CreateTable<PlayGameLogDbModel>();
            _db.CreateTable<SettingsDbModel>();

            var settings = _db.Table<SettingsDbModel>().FirstOrDefault();
            if (settings == null)
            {
                settings = new SettingsDbModel
                {
                    CountryOid = null,
                    CreatedTime = DateTime.Now,
                    CurrentLevel = Common.Enums.EGameLevel.Aday,
                    Deleted = false,
                    Language = LanguageHelperManager.Instance.GetCurrentCultureLanguage().Code,
                    LastUpdateTime = DateTime.Now,
                    Oid = 1,
                    TotalScore = 0,
                    Username = "",
                    SetupDone = false,
                };
                _db.Insert(settings);
            }
            return settings;
        }

        internal SettingsDbModel GetSettings()
        {
            var settings = _db.Table<SettingsDbModel>().FirstOrDefault();
            return settings;

        }

        private SQLiteConnection GetDb(string appName)
        {
            string databaseFileName = Path.Combine(FileSystem.AppDataDirectory, appName + ".db3");
            return new SQLiteConnection(databaseFileName);
        }
    }
}
