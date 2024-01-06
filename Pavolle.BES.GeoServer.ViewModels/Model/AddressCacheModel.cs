using Pavolle.BES.TranslateServer.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Model
{
    public class AddressCacheModel
    {
        public long CountryOid { get; set; }
        public long? CityOid { get; set; }
        public long? DistrictOid { get; set; }
        public string OpenAddress { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public long Oid { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
