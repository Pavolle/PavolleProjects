using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("countries")]
    public class Country : BaseObject
    {
        public Country(Session session) : base(session) {}

        [Persistent("iso2")]
        [Size(2)]
        public string ISOCode2 { get; set; }

        [Persistent("iso3")]
        [Size(3)]
        public string ISOCode3 { get; set; }

        [Persistent("phone_code")]
        [Size(5)]
        public string PhoneCode { get; set; }

        [Persistent("name_td_oid")]
        public TranslateData Name { get; set; }

    }
}
