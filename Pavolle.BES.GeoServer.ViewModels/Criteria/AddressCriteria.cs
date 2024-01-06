using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Criteria
{
    public class AddressCriteria : IntegrationAppRequestBase
    {
        public long? CountryOid { get; set; }
        public long? CityOid { get; set; }
        public long? DistrictOid { get; set; }
        public List<long> AddressOidList { get; set; }
    }
}
