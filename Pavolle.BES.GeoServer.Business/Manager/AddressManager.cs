using Pavolle.BES.GeoServer.ViewModels.Criteria;
using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.GeoServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class AddressManager : Singleton<AddressManager>
    {
        private AddressManager() { }

        public object AddAddress(AddAddressRequest request)
        {
            throw new NotImplementedException();
        }

        public object Delete(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object Edit(long? oid, EditAddressRequest request)
        {
            throw new NotImplementedException();
        }

        public AddressListResponse List(AddressCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(AddressCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
