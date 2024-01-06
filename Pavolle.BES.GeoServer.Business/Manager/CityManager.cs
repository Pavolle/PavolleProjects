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

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class CityManager :  Singleton<CityManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryManager));
        ConcurrentDictionary<long?, CityCacheModel> _cities;
        bool _isCacheInitiliaze = false;
        private CityManager()
        {
            _log.Debug("Initilize " + nameof(CityManager));
        }

        public void Initilaize()
        {
            _cities=new ConcurrentDictionary<long?, CityCacheModel>(); 
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

                    _cities.TryAdd(cacheData.Oid, cacheData);
                }
                _isCacheInitiliaze = true;
            }
        }

        public BesAddRecordResponseBase AddCity(AddCityRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Delete(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public CityDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Edit(long? oid, EditCityRequest request)
        {
            throw new NotImplementedException();
        }

        public CityListResponse List(CityCriteria request)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(CityCriteria request)
        {
            throw new NotImplementedException();
        }

        internal List<CityViewData> GetCityListForCountry(long oid)
        {
            throw new NotImplementedException();
        }
    }
}
