using DevExpress.Xpo;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("countries")]
    public class Country : BaseObject
    {
        public Country(Session session) : base(session)
        {
        }

        [Persistent("iso2")]
        public string ISOCode2 { get; set; }

        [Persistent("iso3")]
        public string ISOCode3 { get; set; }

        [Persistent("phone_code")]
        public string PhoneCode { get; set; }

        [Persistent("name_td_oid")]
        public TranslateData Name { get; set; }

        [Persistent("flag_base64")]
        [Size(3000)]
        public string FlagBase64 { get; set; }
    }
}
