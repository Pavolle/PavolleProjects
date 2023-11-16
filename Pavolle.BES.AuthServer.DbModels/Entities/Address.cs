using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("addresses")]
    public class Address :BaseObject
    {
        public Address(Session session) : base(session)
        {
        }

        [Persistent("address_string")]
        [Size(1000)]
        public string AddressString { get; set; }

        [Persistent("langitude")]
        public double? Langitude { get; set; }

        [Persistent("latitude")]
        public double? Latitude { get; set; }
    }
}
