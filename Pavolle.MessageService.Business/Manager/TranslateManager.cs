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
using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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

        public TranslateDataListResponse List(ListTranslateDataCriteria criteria)
        {
            var response = new TranslateDataListResponse();

            try
            {
                if (criteria == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                    _log.Error("Criteria is null");
                    return response;
                }

                if (criteria.Language == null)
                {
                    _log.Warn("Request language is null. Setted default language.");
                    criteria.Language = SettingManager.Instance.GetDefaultLanguage();
                }

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    IQueryable<TranslateData> query = session.Query<TranslateData>();
                    response.DataList = query.Select(t => new TranslateDataViewData
                    {
                        Oid = t.Oid,
                        CreatedTime = t.CreatedTime,
                        LastUpdateTime = t.LastUpdateTime,
                        Variable = t.Variable,
                        TR = t.TR,
                        EN = t.EN
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public TranslateDataDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            var response = new TranslateDataDetailResponse();

            try
            {
                if (request == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                    _log.Error("Criteria is null");
                    return response;
                }

                if (request.Language == null)
                {
                    _log.Warn("Request language is null. Setted default language.");
                    request.Language = SettingManager.Instance.GetDefaultLanguage();
                }

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    response.Detail = session.Query<TranslateData>().Where(t => t.Oid == oid).Select(t => new TranslateDataDetailViewData
                    {
                        Oid = t.Oid,
                        CreatedTime = t.CreatedTime,
                        LastUpdateTime = t.LastUpdateTime,
                        Variable = t.Variable,
                        TR = t.TR,
                        EN = t.EN
                    }).FirstOrDefault();

                    if (response.Detail == null)
                    {
                        response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(request.Language.Value, EMessageServiceMessageCode.TranslateData);
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public MessageServiceResponseBase Edit(long? oid, EditTranslateDataRequest request)
        {
            var response = new ApiServiceDetailResponse();

            try
            {
                if (request == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                    _log.Error("Criteria is null");
                    return response;
                }

                if (request.Language == null)
                {
                    _log.Warn("Request language is null. Setted default language.");
                    request.Language = SettingManager.Instance.GetDefaultLanguage();
                }

                string checkResult = ValidationManager.Instance.CheckString(request.TR, true, 0, 1000, true, EMessageServiceMessageCode.TranslateData, request.Language.Value);
                if (checkResult != null)
                {
                    _log.Error("Request Validation Error: " + checkResult);
                    response.ErrorMessage = checkResult;
                    return response;
                }

                checkResult = ValidationManager.Instance.CheckString(request.EN, true, 0, 1000, true, EMessageServiceMessageCode.TranslateData, request.Language.Value);
                if (checkResult != null)
                {
                    _log.Error("Request Validation Error: " + checkResult);
                    response.ErrorMessage = checkResult;
                    return response;
                }

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var data = session.Query<TranslateData>().FirstOrDefault(t => t.Oid == oid);

                    if (data == null)
                    {
                        response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(request.Language.Value, EMessageServiceMessageCode.TranslateData);
                        return response;
                    }
                    session.BeginTransaction();

                    data.TR = request.TR;
                    data.EN = request.EN;
                    data.LastUpdateTime = DateTime.Now;
                    data.Save();

                    session.CommitTransaction();
                }

                LoadTranslateData();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public string GetMessage(EMessageServiceMessageCode messageCode, ELanguage language)
        {
            string message = messageCode.ToString();
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
