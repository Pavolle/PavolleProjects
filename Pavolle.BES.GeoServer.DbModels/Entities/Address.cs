using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.DbModels.Entities
{
    public class Address : BaseObject
    {
        public Address(Session session) : base(session)
        {
        }

        public Country Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string OpenAddress { get; set; }
    }
}
