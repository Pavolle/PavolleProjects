using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.GeoServer.ViewModels.Response;
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
    public class CountryManager : Singleton<CountryManager>
    {
        private CountryManager() { }

        public void Initilaize()
        {

        }

        public BesAddRecordResponseBase AddCountry(AddCountryRequest request)
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

        public ResponseBase Edit(long? oid, EditCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public ImageLookupResponse ImageLookup(IntegrationAppRequestBase criteria)
        {
            throw new NotImplementedException();
        }

        public CountryListResponse List(IntegrationAppRequestBase criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(IntegrationAppRequestBase criteria)
        {
            throw new NotImplementedException();
        }
    }
}
