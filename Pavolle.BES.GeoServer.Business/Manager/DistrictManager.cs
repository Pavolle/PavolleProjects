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
    public class DistrictManager : Singleton<DistrictManager>
    {
        private DistrictManager() { }

        public void Initilaize()
        {

        }

        public BesAddRecordResponseBase AddDistrict(AddDistrictRequest request)
        {
            throw new NotImplementedException();
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
