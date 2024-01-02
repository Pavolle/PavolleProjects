using Pavolle.BES.GeoServer.ViewModels.Criteria;
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
    public class DistrictManager : Singleton<DistrictManager>
    {
        private DistrictManager() { }

        public object AddDistrict(AddDistrictRequest request)
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

        public object Edit(long? oid, EditDistrictRequest request)
        {
            throw new NotImplementedException();
        }

        public object List(DistrictCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public object Lookup(DistrictCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
