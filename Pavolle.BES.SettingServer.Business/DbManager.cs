﻿using log4net;
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
                _log.Info("Connecting to DB...");
                XpoManager.Instance.InitXpo(connectionString);
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
