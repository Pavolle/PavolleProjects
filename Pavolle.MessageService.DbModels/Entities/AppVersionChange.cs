using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("app_version_changes")]
    public class AppVersionChange : BaseObject
    {
        public AppVersionChange(Session session) : base(session)
        {
        }

        [Persistent("version_oid")]
        public AppVersion Version { get; set; }

        [Persistent("exlanation")]
        [Size(1000)]
        public string Explanation { get; set; }
    }
}
