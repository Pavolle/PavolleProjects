using DevExpress.Xpo;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("companies")]
    public class Organization : BaseObject
    {
        public Organization(Session session) : base(session)
        {
        }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("code")]
        [Size(5)]
        public string Code { get; set; }

        [Persistent("address")]
        [Size(1000)]
        public string Address { get; set; }

        [Persistent("langitude")]
        public double? Langitude { get; set; }

        [Persistent("latitude")]
        public double? Latitude { get; set; }

        [Persistent("upper_organization")]
        public int UpperOrganization { get; set; }

        [Persistent("country_oid")]
        public Country Country { get; set; }

        [Persistent("city_oid")]
        public City City { get; set; }

        [Persistent("zip_code")]
        public string ZipCode { get; set; }
    }
}
