using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("bugs")]
    public class Bug : BaseObject
    {
        public Bug(Session session) : base(session)
        {
        }

        [Persistent("version_oid")]
        public AppVersion Version { get; set; }

        [Persistent("summary")]
        public string Summary { get; set; }

        [Persistent("detail")]
        public string Detail { get; set; }
    }
}
