using DevExpress.Xpo;
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
using System.Collections.Concurrent;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class DistrictManager : Singleton<DistrictManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryManager));
        ConcurrentDictionary<long?, DistrictCacheModel> _cacheData;
        bool _isCacheInitiliaze = false;
        private DistrictManager()
        {
            _log.Debug("Initilize " + nameof(DistrictManager));
        }

        public void Initilaize()
        {
            _cacheData = new ConcurrentDictionary<long?, DistrictCacheModel>();
            using (Session session = GeoServerXpoManager.Instance.GetNewSession())
            {
                var dataList = session.Query<District>().ToList();

                foreach (var data in dataList)
                {
                    var cacheData = new DistrictCacheModel
                    {
                        Oid = data.Oid,
                        CreatedTime = data.CreatedTime,
                        DeletedTime = data.DeletedTime,
                        LastUpdateTime = data.LastUpdateTime,
                        NameTranslateModel = TranslateServiceManager.Instance.GetDataByOid(data.NameTranslateDataOid, EBesAppType.GeolocationServer),
                        CityOid = data.City.Oid,
                        CountryOid=data.City.Country.Oid
                    };

                    _cacheData.TryAdd(cacheData.Oid, cacheData);
                }
                _isCacheInitiliaze = true;
            }
        }

        public BesAddRecordResponseBase AddDistrict(AddDistrictRequest request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new BesAddRecordResponseBase();
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
                    var city = session.Query<City>().FirstOrDefault(t => t.Oid == request.CityOid);
                    if (city == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    new District(session)
                    {
                        NameTranslateDataOid = addCityNameResponse.RecordOid.Value,
                        City = city
                    }.Save();

                    _log.Info("District saved to DB. District => " + request.Name);
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
                    var data = session.Query<District>().FirstOrDefault(t => t.Oid == oid);
                    if (data == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    if (session.Query<Address>().Any(t => t.District.Oid == oid))
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordCannotBeDeleted, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    data.DeletedTime = DateTime.Now;
                    data.Save();

                    data.Delete();
                    _log.Warn("District deleted succeded. District Oid => " + data.Oid);
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

        public DistrictDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new DistrictDetailResponse();
            DistrictCacheModel? data = null;
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

            response.Detail = new DistrictDetailViewData
            {
                Oid = data.Oid,
                CountyDetail = CountryManager.Instance.GetCountryDetail(data.CountryOid, request.Language),
                CityDetail = CityManager.Instance.GetCityDetail(data.CityOid, request.Language),
                CreatedTime = data.CreatedTime,
                LastUpdateTime = data.LastUpdateTime,
                Name = TranslateServiceManager.Instance.GetNameFromCacheData(data.NameTranslateModel, request.Language)
            };

            return response;
        }

        public ResponseBase Edit(long? oid, EditDistrictRequest request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new ResponseBase();

            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {
                    var city = session.Query<Country>().FirstOrDefault(t => t.Oid == request.CityOid);
                    if (city == null)
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

        //todo criteriaya eklenecek, country ve city detayları da eklenecek.
        public DistrictListResponse List(DistrictCriteria criteria)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new DistrictListResponse();
            response.DataList = _cacheData.Values.Select(t => new DistrictViewData
            {
                Oid = t.Oid,
                CreatedTime = t.CreatedTime,
                LastUpdateTime = t.LastUpdateTime,
                Name = TranslateServiceManager.Instance.GetNameFromCacheData(t.NameTranslateModel, criteria.Language),
            }).ToList();
            return response;
        }

        public LookupResponse Lookup(DistrictCriteria criteria)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new LookupResponse();
            response.DataList = _cacheData.Values.ToList().Where(t => t.CityOid == criteria.CityOid)
                                                .Select(t => new LookupViewData
                                                {
                                                    Key = t.Oid,
                                                    Value = TranslateServiceManager.Instance.GetNameFromCacheData(t.NameTranslateModel, criteria.Language),
                                                    IsDefault = false
                                                }).ToList();
            return response;
        }

        internal List<DistrictViewData> GetDistrictListForCity(long oid)
        {
            throw new NotImplementedException();
        }
    }
}
