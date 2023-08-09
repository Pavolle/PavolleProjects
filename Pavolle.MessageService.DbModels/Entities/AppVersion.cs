using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("app_versions")]
    public class AppVersion : BaseObject
    {
        public AppVersion(Session session) : base(session)
        {
        }

        [Persistent("app_oid")]
        public App App { get; set; }

        [Persistent("version_code")]
        public string VersionCode { get; set; }

        [Persistent("release_date")]
        public string ReleaseDate { get; set; }
    }
}
