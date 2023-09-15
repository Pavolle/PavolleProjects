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
    public class TranslateManager:Singleton<TranslateManager>
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
                        TR = t.TR
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
                if(_translateData.ContainsKey(item.Variable))
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

        public TranslateDataListResponse List(ListTranslateDataCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public TranslateDataDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditTranslateDataRequest request)
        {
            throw new NotImplementedException();
        }

        public string GetMessage(EMessageServiceMessageCode messageCode, ELanguage language)
        {
            string message=messageCode.ToString();
            TranslateDataCacheModel data;
            if(_translateData.ContainsKey(messageCode.ToString()))
            {
                data=_translateData[messageCode.ToString()];
            }
            else
            {
                return message;
            }
            
            switch (language)
            {
                case ELanguage.Turkce:
                    message = data.TR;
                    break;
                case ELanguage.Ingilizce:
                    message = data.EN;
                    break;
                default:
                    message = data.EN;
                    break;
            }

            return message;
        }

        internal string GetXNotFoundMessage(ELanguage language, EMessageServiceMessageCode messageCode)
        {
            return string.Format(GetMessage(EMessageServiceMessageCode.XNotFound, language), messageCode);
        }
    }
}
