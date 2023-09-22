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

        public void InitilaizeDb(string appName)
        {
            _db = GetDb(appName);
            _db.CreateTable<PlayGameLogDbModel>();
            _db.CreateTable<SettingsDbModel>();

            var settings = _db.Table<SettingsDbModel>().FirstOrDefault();
            if (settings == null)
            {
                _db.Insert(new SettingsDbModel
                {
                    CountryOid=null,
                    CreatedTime=DateTime.Now,
                    CurrentLevel=Common.Enums.EGameLevel.Aday,
                    Deleted=false,
                    //Language
                });
            }
        }

        private SQLiteConnection GetDb(string appName)
        {
            string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "PavolleApps");
            System.IO.Directory.CreateDirectory(applicationFolderPath);
            string databaseFileName = System.IO.Path.Combine(applicationFolderPath, appName + ".db");

            var db = new SQLiteConnection(databaseFileName);

            return db;

        }
    }
}
