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
    public class TranslateManager : Singleton<TranslateManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(TranslateManager));
        private ConcurrentDictionary<string, TranslateDataCacheModel> _translateData;
        private TranslateManager()

        {
            LoadTranslateData();
            _log.Debug("Initialize " + nameof(TranslateManager));
        }

        private void LoadTranslateData()
        {
            try
            {
                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var datas = session.Query<TranslateData>().Select(t => new TranslateDataCacheModel
                    {
                        Oid = t.Oid,
                        Variable = t.Variable,
                        EN = t.EN,
                        TR = t.TR,
                    }).ToList();

                    _translateData = new ConcurrentDictionary<string, TranslateDataCacheModel>();
                    foreach (var item in datas)
                    {
                        _translateData.TryAdd(item.Variable, item);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
            }
        }

        private void AddTranslateData(TranslateDataCacheModel item)
        {
            try
            {
                _translateData.TryAdd(item.Variable, item);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
            }
        }

        private void UpdateTranslateData(TranslateDataCacheModel item)
        {
            try
            {
                if (_translateData.ContainsKey(item.Variable))
                {
                    _translateData[item.Variable] = item;
                }
                else
                {
                    _translateData.TryAdd(item.Variable, item);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
            }
        }

        public string GetMessage(EMessageCode messageCode, ELanguage language)
        {
            return GetMessage(messageCode.ToString(), language);
        }

        public string GetMessage(string messageCode, ELanguage language)
        {
            string message = messageCode;
            TranslateDataCacheModel data;
            if (_translateData.ContainsKey(messageCode.ToString()))
            {
                data = _translateData[messageCode.ToString()];
            }
            else
            {
                return message;
            }

            switch (language)
            {
                case ELanguage.English:
                    message = data.EN;
                    break;
                case ELanguage.Turkish:
                    message = data.TR;
                    break;
                default:
                    message = data.EN;
                    break;
            }
            return message;
        }

        public string GetXNotFoundMessage(ELanguage language, EMessageCode messageCode)
        {
            return string.Format(GetMessage(EMessageCode.XNotFound, language), messageCode);
        }

        public string? GetXSavedMessage(ELanguage language, EMessageCode messageCode)
        {
            return string.Format(GetMessage(EMessageCode.XSaved, language), messageCode);
        }

        public string? GetXCannotBeDeletedessage(ELanguage language, EMessageCode messageCode)
        {
            return string.Format(GetMessage(EMessageCode.XCannotBeDeleted, language), messageCode);
        }

        internal string? GetXDeletedMessage(ELanguage language, EMessageCode messageCode)
        {
            return string.Format(GetMessage(EMessageCode.XDeleted, language), messageCode);
        }
    }
}
