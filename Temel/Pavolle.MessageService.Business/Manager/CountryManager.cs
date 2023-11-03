using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
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
    public class CountryManager:Singleton<CountryManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryManager));
        ConcurrentDictionary<long, CountryCacheModel> _cacheData;
        private CountryManager() { }

        public void Initialize()
        {
            LoadCacheData();
        }

        private void LoadCacheData()
        {
            throw new NotImplementedException();
        }

        public CountryListResponse List(ListCountryCriteria criteria)
        {
            var response = new CountryListResponse();

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
                    List<Country> query = session.Query<Country>().ToList();
                    response.DataList = new List<CountryViewData>();
                    foreach (var item in query.ToList())
                    {
                        response.DataList.Add(new CountryViewData
                        {
                            Oid = item.Oid,
                            CreatedTime = item.CreatedTime,
                            LastUpdateTime = item.LastUpdateTime,
                            Name = TranslateManager.Instance.GetMessage(item.Name.Variable, criteria.Language.Value)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public LookupResponse Lookup(LookupCountryCriteria criteria)
        {
            var response = new LookupResponse();

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
                    List<Country> query = session.Query<Country>().ToList();
                    response.DataList = new List<LookupViewData>();
                    foreach (var item in query.ToList())
                    {
                        response.DataList.Add(new LookupViewData
                        {
                            Key = item.Oid,
                            Value = TranslateManager.Instance.GetMessage(item.Name.Variable, criteria.Language.Value),
                            IsDefault = false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public ImageLookupResponse ImageLookup(LookupCountryCriteria criteria)
        {
            var response = new ImageLookupResponse();

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
                    List<Country> query = session.Query<Country>().ToList();
                    response.DataList = new List<ImageLookupViewData>();
                    foreach (var item in query.ToList())
                    {
                        response.DataList.Add(new ImageLookupViewData
                        {
                            Key = item.Oid,
                            Value = TranslateManager.Instance.GetMessage(item.Name.Variable, criteria.Language.Value),
                            ImageBase64=item.FlagBase64,
                            IsDefault = false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public CountryDetailResponse Detail(long? oid, MessageServiceRequestBase criteria)
        {
            var response = new CountryDetailResponse();

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
                    var data = session.Query<Country>().FirstOrDefault(t => t.Oid == oid);
                    if (data == null)
                    {
                        response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(criteria.Language.Value, EMessageCode.City);
                        return response;
                    }

                    response.Detail = new CountryDetailViewData
                    {
                        Oid = data.Oid,
                        CreatedTime = data.CreatedTime,
                        LastUpdateTime = data.LastUpdateTime,
                        NameTranslateDataOid = data.Name.Oid,
                        Name = TranslateManager.Instance.GetMessage(data.Name.Variable, criteria.Language.Value)
                    };

                    response.CityList = CityManager.Instance.List(new ListCityCriteria
                    {
                        CountryOids = new List<long> { data.Oid },
                        Language = criteria.Language,
                        RequestIp = criteria.RequestIp,
                        SessionId = criteria.SessionId,
                        UserGroupOid = criteria.UserGroupOid,
                        Username = criteria.Username,
                        UserType = criteria.UserType
                    }).DataList;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public MessageServiceResponseBase Add(AddCountryRequest request)
        {
            var response = new MessageServiceResponseBase();

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
                    session.BeginTransaction();

                    var nameTranslateData = new TranslateData(session)
                    {
                        Variable = request.Name
                    };
                    if (request.Language == ELanguage.Turkish)
                    {
                        nameTranslateData.TR = request.Name;
                    }
                    else if (request.Language == ELanguage.English)
                    {
                        nameTranslateData.EN = request.Name;
                    }

                    nameTranslateData.Save();
                    var city = new Country(session)
                    {
                        ISOCode2=request.ISOCode2,
                        ISOCode3 = request.ISOCode3,
                        FlagBase64=request.FlagBase64,
                        Name = nameTranslateData
                    };
                    city.Save();

                    session.CommitTransaction();

                    response.SuccessMessage = TranslateManager.Instance.GetXSavedMessage(request.Language.Value, EMessageCode.City);

                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public MessageServiceResponseBase Edit(long? oid, EditCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Delete(long? oid, DeleteCountryCriteria request)
        {
            throw new NotImplementedException();
        }
    }
}
