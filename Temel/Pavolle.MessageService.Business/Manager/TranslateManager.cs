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
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
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
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, criteria.Language.Value);
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
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
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
                    var t = session.Query<TranslateData>().FirstOrDefault(t => t.Oid == oid);
                    if(t == null)
                    {
                        response.ErrorMessage = GetXNotFoundMessage(request.Language.Value, EMessageCode.TranslateData);
                    }
                    else
                    {
                        response.Detail = new TranslateDataDetailViewData
                        {
                            Oid = t.Oid,
                            CreatedTime = t.CreatedTime,
                            LastUpdateTime = t.LastUpdateTime,
                            Variable = t.Variable,
                            TR = t.TR,
                            EN = t.EN
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, request.Language.Value);
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
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                    _log.Error("Criteria is null");
                    return response;
                }

                if (request.Language == null)
                {
                    _log.Warn("Request language is null. Setted default language.");
                    request.Language = SettingManager.Instance.GetDefaultLanguage();
                }

                string checkResult = ValidationManager.Instance.CheckString(request.TR, true, 0, 1000, true, EMessageCode.TranslateData, request.Language.Value);
                if (checkResult != null)
                {
                    _log.Error("Request Validation Error: " + checkResult);
                    response.ErrorMessage = checkResult;
                    return response;
                }

                checkResult = ValidationManager.Instance.CheckString(request.EN, true, 0, 1000, true, EMessageCode.TranslateData, request.Language.Value);
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
                        response.ErrorMessage = GetXNotFoundMessage(request.Language.Value, EMessageCode.TranslateData);
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
                response.ErrorMessage = GetMessage(EMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public string GetMessage(EMessageCode messageCode, ELanguage language)
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
                case ELanguage.Turkish:
                    message = data.TR;
                    break;
                case ELanguage.English:
                    message = data.EN;
                    break;
                default:
                    message = data.EN;
                    break;
            }

            return message;
        }

        public string GetMessage(string variable, ELanguage language)
        {
            string message = variable;
            TranslateDataCacheModel data;
            if (_translateData.ContainsKey(variable))
            {
                data = _translateData[variable];
            }
            else
            {
                return message;
            }

            switch (language)
            {
                case ELanguage.Turkish:
                    message = data.TR;
                    break;
                case ELanguage.English:
                    message = data.EN;
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
