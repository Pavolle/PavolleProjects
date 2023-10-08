using DevExpress.Xpo;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("organizations")]
    public class Organization : BaseObject
    {
        public Organization(Session session) : base(session) {}

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

        [Persistent("upper_organization_oid")]
        public Organization UpperOrganization { get; set; }

        [Persistent("country_oid")]
        public Country Country { get; set; }

        [Persistent("city_oid")]
        public City City { get; set; }

        [Persistent("zip_code")]
        [Size(20)]
        public string ZipCode { get; set; }

        [Persistent("logo_base64")]
        [Size(3000)]
        public string LogoBase64 { get; set; }

    }
}
