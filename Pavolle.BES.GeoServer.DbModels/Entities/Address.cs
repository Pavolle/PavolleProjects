using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.DbModels.Entities
{
    [Persistent("address")]
    public class Address : BaseObject
    {
        public Address(Session session) : base(session)
        {
        }

        [Persistent("country_oid")]
        public Country Country { get; set; }

        [Persistent("city_oid")]
        public City City { get; set; }

        [Persistent("district_oid")]
        public District District { get; set; }

        [Persistent("open_address")]
        public string OpenAddress { get; set; }

        [Persistent("street_name")]
        public string StreetName { get; set; }

        [Persistent("zip_code")]
        public string ZipCode { get; set; }

        [Persistent("latitude")]
        public double Latitude { get; set; }

        [Persistent("longitude")]
        public double Longitude { get; set; }
    }
}
