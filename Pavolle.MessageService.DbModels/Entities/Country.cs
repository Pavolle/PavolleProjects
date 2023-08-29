using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    public class Country : BaseObject
    {
        public Country(Session session) : base(session)
        {
        }

        public string ISOCode3 { get; set; }
        public int ISOCode2 { get; set; }
        public TranslateData Name { get; set; }
    }
}
