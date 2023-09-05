using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class SettingManager:Singleton<SettingManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SettingManager));
        private ConcurrentDictionary<ESettingType, SettingCacheModel> _settings;
        private SettingManager(){}

        public void Intialize()
        {
            _settings = new ConcurrentDictionary<ESettingType, SettingCacheModel>();

            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var settingList = session.Query<Setting>().Select(t => new SettingCacheModel
                {
                    Oid=t.Oid,
                    SettingType=t.SettingType,
                    Value=t.Value
                });
            }
        }

        private void SetupFirstSettings()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                CreateSettingRow(session, ESettingType.SchedulerControlCron, "Scheduler Control Cron", "");
                CreateSettingRow(session, ESettingType.SecurityLevel, "Security Level", ((int)ESecurityLevel.Master).ToString());
                CreateSettingRow(session, ESettingType.DefaultLanguage, "Default Language", ((int)ELanguage.Turkce).ToString());
                CreateSettingRow(session, ESettingType.ResetCodeLenght, "Reset Code Lenght", "6");
            }
        }

        private void CreateSettingRow(Session session, ESettingType settingType, string name, string value)
        {
            if (!session.Query<Setting>().Any(t => t.SettingType == settingType))
            {
                new Setting(session)
                {
                    SettingType = settingType,
                    Value = value,
                    SettingName = name
                }.Save();
            }
        }

        public ELanguage GetDefaultLanguage()
        {
            try
            {
                if (_settings.ContainsKey(ESettingType.DefaultLanguage))
                {
                    return (ELanguage)Convert.ToInt32(_settings[ESettingType.DefaultLanguage].Value);
                }
                return ELanguage.Ingilizce;
            }
            catch (Exception ex)
            {
                _log.Error("Fetch Default Language setting error: " + ex);
                return ELanguage.Ingilizce;
            }
        }

        public ESecurityLevel GetSecurityLevel()
        {
            try
            {
                if (_settings.ContainsKey(ESettingType.SecurityLevel))
                {
                    return (ESecurityLevel)Convert.ToInt32(_settings[ESettingType.SecurityLevel].Value);
                }
                return ESecurityLevel.Master;
            }
            catch (Exception ex)
            {
                _log.Error("Fetch Security Level setting error: " + ex);
                return ESecurityLevel.Master;
            }
        }

        public object? List(ListSettingCriteria request)
        {
            throw new NotImplementedException();
        }

        public object? Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditSettingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
