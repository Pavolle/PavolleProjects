using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("translate_datas")]
    public class TranslateData : BaseObject
    {
        public TranslateData(Session session) : base(session)
        {
        }

        [Persistent("variable")]
        [Indexed(Unique = true, Name = "index_translate_datas_variable")]
        [Size(1000)]
        public string Variable { get; set; }

        [Persistent("tr")]
        [Size(1000)]
        public string TR { get; set; }

        [Persistent("en")]
        [Size(1000)]
        public string EN { get; set; }
    }
}
