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
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pavolle.BES.TranslateServer.Common.Enums;

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
                        CityOid = data.City.Oid
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
            throw new NotImplementedException();
        }

        public DistrictDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Edit(long? oid, EditDistrictRequest request)
        {
            throw new NotImplementedException();
        }

        public DistrictDetailResponse List(DistrictCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(DistrictCriteria criteria)
        {
            throw new NotImplementedException();
        }

        internal List<DistrictViewData> GetDistrictListForCity(long oid)
        {
            throw new NotImplementedException();
        }
    }
}
