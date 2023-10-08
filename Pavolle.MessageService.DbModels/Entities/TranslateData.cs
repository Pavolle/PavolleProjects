using DevExpress.Xpo;

namespace Pavolle.MessageService.DbModels.Entities
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

        [Persistent("en")]
        [Size(1000)]
        public string EN { get; set; }

        [Persistent("tr")]
        [Size(1000)]
        public string TR { get; set; }

    }
}
