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
    public class SettingManager:Singleton<SettingManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SettingManager));
        private ConcurrentDictionary<ESettingType, SettingCacheModel> _settings;

        private SettingManager()
        {
            _log.Debug("Initialize "+nameof(SettingManager));
        }

        public void Intialize()
        {
            _settings = new ConcurrentDictionary<ESettingType, SettingCacheModel>();
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var settingList = session.Query<Setting>().Select(t => new SettingCacheModel
                {
                    Oid = t.Oid,
                    SettingType = t.SettingType,
                    Value = t.Value
                });
            }
        }

        private void UpdateSetting(SettingCacheModel item)
        {
            try
            {
                if (_settings.ContainsKey(item.SettingType))
                {
                    _settings[item.SettingType] = item;
                }
                else
                {
                    _settings.TryAdd(item.SettingType, item);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
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
                return ELanguage.English;
            }
            catch (Exception ex)
            {
                _log.Error("Fetch Deufault Setting error: " + ex);
                return ELanguage.English;
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

        public string GetSetting(ESettingType settingType)
        {
            try
            {
                if (_settings.ContainsKey(settingType))
                {
                    return _settings[settingType].Value;
                }
            }
            catch (Exception ex)
            {
                _log.Error("Fetch setting error: " + ex);
            }
            return "";
        }
    }
}
