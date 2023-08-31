using DevExpress.Xpo;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("translate_datas")]
    public class TranslateData : BaseObject
    {
        public TranslateData(Session session) : base(session)
        {
        }

        [Persistent("variable")]
        [Size(1000)]
        public string Variable { get; set; }

        [Persistent("tr")]
        [Size(1000)]
        public string TR { get; set; }

        [Persistent("en")]
        [Size(1000)]
        public string EN { get; set; }

        [Persistent("az")]
        [Size(1000)]
        public string AZ { get; set; }

        [Persistent("ru")]
        [Size(1000)]
        public string RU { get; set; }

        [Persistent("es")]
        [Size(1000)]
        public string ES { get; set; }

        [Persistent("fr")]
        [Size(1000)]
        public string FR { get; set; }

    }
}
