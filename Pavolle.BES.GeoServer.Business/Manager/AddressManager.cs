using Pavolle.BES.GeoServer.ViewModels.Criteria;
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
    public class AddressManager : Singleton<AddressManager>
    {
        private AddressManager() { }

        public void Initilaize()
        {

        }

        //TODO Burada oid bilgisini geri dönmemiz gerekebilir. Çünkü bu oid bilgisi bir yerlere yazılacak.
        public BesAddRecordResponseBase AddAddress(AddAddressRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Delete(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public AddressDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Edit(long? oid, EditAddressRequest request)
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
