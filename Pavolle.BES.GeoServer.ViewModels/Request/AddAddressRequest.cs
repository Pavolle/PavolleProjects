using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Request
{
    public class AddAddressRequest : IntegrationAppRequestBase
    {
        public long? CountryOid { get; set; }
        public long? CityOid { get; set; }
        public long? DistrictOid { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string StreetName { get; set; }
        public string OpenAddress { get; set; }
        public string ZipCode { get; set; }
    }
}
