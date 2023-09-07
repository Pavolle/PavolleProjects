using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("cities")]
    public class City : BaseObject
    {
        public City(Session session) : base(session) {}

        [Persistent("code")]
        [Size(20)]
        public string Code { get; set; }

        [Persistent("country_oid")]
        public Country Country { get; set; }

        [Persistent("name_td_oid")]
        public TranslateData Name { get; set; }

    }
}
