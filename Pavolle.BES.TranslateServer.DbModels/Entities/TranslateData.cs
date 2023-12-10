using DevExpress.Xpo;
using Pavolle.BES.AppServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.DbModels.Entities
{
    [Persistent("translate_datas")]
    public class TranslateData : BaseObject
    {
        public TranslateData(Session session) : base(session)
        {
        }

        [Persistent("variable")]
        [Size(2000)]
        public string Variable { get; set; }

        [Persistent("bes_app_type")]
        public EBesAppType? AppType { get; set; }

        [Persistent("tr")]
        [Size(2000)]
        public string TR { get; set; }

        [Persistent("en")]
        [Size(2000)]
        public string EN { get; set; }

        [Persistent("es")]
        [Size(2000)]
        public string ES { get; set; }

        [Persistent("fr")]
        [Size(2000)]
        public string FR { get; set; }

        [Persistent("ru")]
        [Size(2000)]
        public string RU { get; set; }

        [Persistent("de")]
        [Size(2000)]
        public string DE { get; set; }

        [Persistent("az")]
        [Size(2000)]
        public string AZ { get; set; }
    }
}
