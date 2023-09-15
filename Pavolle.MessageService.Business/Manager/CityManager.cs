using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
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
    public class CityManager : Singleton<CityManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CityManager));
        ConcurrentDictionary<long, CityCacheModel> _cacheData;
        private CityManager() 
        {

            LoadCacheData();
            _log.Debug("Inialize " + nameof(CityManager));
        }

        private void LoadCacheData()
        {
            try
            {
                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var services = session.Query<City>().Select(t => new CityCacheModel
                    {
                        Oid = t.Oid,
                        Code = t.Code,
                        Name = t.Name.Variable,
                        CountryName = t.Country.Name.Variable,
                        CountryOid = t.Country.Oid,
                    }).ToList();

                    _cacheData = new ConcurrentDictionary<long, CityCacheModel>();
                    foreach (var item in services)
                    {
                        _cacheData.TryAdd(item.Oid, item);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
            }
        }

        public CityListResponse List(ListCityCriteria criteria)
        {
            var response = new CityListResponse();

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
                    List<City> query = session.Query<City>().ToList();
                    if (criteria.CountryOids != null && criteria.CountryOids.Count>0)
                    {
                        query = query.Where(t => criteria.CountryOids.Contains(t.Country.Oid)).ToList();
                    }
                    response.DataList = new List<CityViewData>();
                    foreach (var item in query.ToList())
                    {
                        response.DataList.Add(new CityViewData
                        {
                            Oid = item.Oid,
                            CountryOid = item.Country.Oid,
                            CreatedTime = item.CreatedTime,
                            LastUpdateTime = item.LastUpdateTime,
                            Code = item.Code,
                            Name = TranslateManager.Instance.GetMessage(item.Name.Variable, criteria.Language.Value),
                            CountryName = TranslateManager.Instance.GetMessage(item.Country.Name.Variable, criteria.Language.Value)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public LookupResponse Lookup(LookupCityCriteria criteria)
        {
            var response = new LookupResponse();

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
                    List<City> query = session.Query<City>().ToList();
                    if (criteria.CountryOid != null)
                    {
                        query = query.Where(t => t.Country.Oid==criteria.CountryOid).ToList();
                    }
                    response.DataList = new List<LookupViewData>();
                    foreach (var item in query.ToList())
                    {
                        response.DataList.Add(new LookupViewData
                        {
                            Key = item.Oid,
                            Value = TranslateManager.Instance.GetMessage(item.Name.Variable, criteria.Language.Value),
                            IsDefault=false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public CityDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AddCityRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditCityRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Delete(long? oid, DeleteCityCriteria request)
        {
            throw new NotImplementedException();
        }
    }
}
