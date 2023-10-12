using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.DbModels.Manager;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using System.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class DbManager : Singleton<DbManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(DbManager));

        private DbManager()
        {
            _log.Debug("Initialize "+nameof(DbManager));
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
