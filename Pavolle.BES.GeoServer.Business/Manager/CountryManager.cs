using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
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

        public object AddCountry(AddCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public object Delete(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object Detail(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object Edit(long? oid, EditCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public object ImageLookup(IntegrationAppRequestBase criteria)
        {
            throw new NotImplementedException();
        }

        public object List(IntegrationAppRequestBase criteria)
        {
            throw new NotImplementedException();
        }

        public object Lookup(IntegrationAppRequestBase criteria)
        {
            throw new NotImplementedException();
        }
    }
}
