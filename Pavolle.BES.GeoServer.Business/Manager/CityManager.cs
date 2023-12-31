﻿using DevExpress.Xpo;
using log4net;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.GeoServer.DbModels.Entities;
using Pavolle.BES.GeoServer.DbModels;
using Pavolle.BES.GeoServer.ViewModels.Criteria;
using Pavolle.BES.GeoServer.ViewModels.Model;
using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.GeoServer.ViewModels.Response;
using Pavolle.BES.GeoServer.ViewModels.ViewData;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.TranslateServer.Common.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Pavolle.BES.Business.Manager;
using Pavolle.Core.ViewModels.ViewData;
using Pavolle.Core.Enums;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class CityManager :  Singleton<CityManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryManager));
        ConcurrentDictionary<long?, CityCacheModel> _cacheData;
        bool _isCacheInitiliaze = false;
        private CityManager()
        {
            _log.Debug("Initilize " + nameof(CityManager));
        }

        public void Initilaize()
        {
            _cacheData=new ConcurrentDictionary<long?, CityCacheModel>(); 
            using (Session session = GeoServerXpoManager.Instance.GetNewSession())
            {
                var dataList = session.Query<City>().ToList();

                foreach (var data in dataList)
                {
                    var cacheData = new CityCacheModel
                    {
                        Oid = data.Oid,
                        CreatedTime = data.CreatedTime,
                        DeletedTime = data.DeletedTime,
                        LastUpdateTime = data.LastUpdateTime,
                        NameTranslateModel = TranslateServiceManager.Instance.GetDataByOid(data.NameTranslateDataOid, EBesAppType.GeolocationServer),
                        CountryOid=data.Country.Oid
                    };

                    _cacheData.TryAdd(cacheData.Oid, cacheData);
                }
                _isCacheInitiliaze = true;
            }
        }

        public BesAddRecordResponseBase AddCity(AddCityRequest request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response= new BesAddRecordResponseBase();
            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {
                    var addCityNameResponse = TranslateServiceManager.Instance.SaveNewData(request.Name, request.Language, EBesAppType.GeolocationServer);
                    if (addCityNameResponse == null || !addCityNameResponse.Success)
                    {
                        _log.Error("Translate Server ERROR");
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }
                    var country=session.Query<Country>().FirstOrDefault(t=>t.Oid==request.CountryOid);
                    if (country == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    new City(session)
                    {
                        NameTranslateDataOid = addCityNameResponse.RecordOid.Value,
                        Country = country
                    }.Save();

                    _log.Info("City saved to DB. City => " + request.Name);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }

            Initilaize();
            return response;
        }

        public ResponseBase Delete(long? oid, IntegrationAppRequestBase request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new ResponseBase();

            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {
                    var data = session.Query<City>().FirstOrDefault(t => t.Oid == oid);
                    if (data == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    if (session.Query<District>().Any(t => t.City.Oid == oid))
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordCannotBeDeleted, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    data.DeletedTime = DateTime.Now;
                    data.Save();

                    data.Delete();
                    _log.Warn("City deleted succeded. City Oid => " + data.Oid);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }

            Initilaize();
            return response;
        }

        public CityDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new CityDetailResponse();
            CityCacheModel? data = null;
            if (_cacheData.ContainsKey(oid))
            {
                data = _cacheData[oid];
            }
            if (data == null)
            {
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                response.StatusCode = 500;
                return response;
            }

            response.Detail = new CityDetailViewData
            {
                Oid = data.Oid,
                CountyDetail = CountryManager.Instance.GetCountryDetail(data.CountryOid, request.Language),
                CreatedTime = data.CreatedTime,
                LastUpdateTime = data.LastUpdateTime,
                Name = TranslateServiceManager.Instance.GetNameFromCacheData(data.NameTranslateModel, request.Language)
            };

            response.DistrictList = DistrictManager.Instance.GetDistrictListForCity(data.Oid, request.Language.Value);
            return response;
        }

        public ResponseBase Edit(long? oid, EditCityRequest request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new BesAddRecordResponseBase();

            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {
                    var country = session.Query<Country>().FirstOrDefault(t => t.Oid == request.CountryOid);
                    if (country == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }

            Initilaize();

            return response;
        }

        public CityListResponse List(CityCriteria request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new CityListResponse();
            response.DataList = _cacheData.Values.Select(t => new CityViewData
            {
                Oid = t.Oid,
                CreatedTime = t.CreatedTime,
                LastUpdateTime = t.LastUpdateTime,
                Name = TranslateServiceManager.Instance.GetNameFromCacheData(t.NameTranslateModel, request.Language),
            }).ToList();
            return response;
        }

        public LookupResponse Lookup(CityCriteria criteria)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new LookupResponse();
            response.DataList = _cacheData.Values.ToList().Where(t=>t.CountryOid==criteria.CountryOid)
                                                .Select(t => new LookupViewData
                                                {
                                                    Key = t.Oid,
                                                    Value = TranslateServiceManager.Instance.GetNameFromCacheData(t.NameTranslateModel, criteria.Language),
                                                    IsDefault = false
                                                }).ToList();
            return response;
        }

        internal List<CityViewData> GetCityListForCountry(long oid, ELanguage language)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            return _cacheData.Values.Where(t => t.CountryOid == oid).Select(t => new CityViewData
            {
                Oid = t.Oid,
                CreatedTime = t.CreatedTime,
                LastUpdateTime = t.LastUpdateTime,
                Name= TranslateServiceManager.Instance.GetNameFromCacheData(t.NameTranslateModel, language),
            }).ToList();
        }

        internal CityDetailViewData GetCityDetail(long cityOid, ELanguage? language)
        {
            throw new NotImplementedException();
        }
    }
}
