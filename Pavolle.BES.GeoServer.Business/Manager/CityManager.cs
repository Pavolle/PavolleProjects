using log4net;
using Pavolle.BES.GeoServer.ViewModels.Criteria;
using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.GeoServer.ViewModels.Response;
using Pavolle.BES.GeoServer.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class CityManager :  Singleton<CityManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryManager));
        private CityManager() 
        {
        }

        public void Initilaize()
        {

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
