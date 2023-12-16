using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AppServer.DbModels.Entities
{
    [Persistent("app_version")]
    public class Version : BaseObject
    {
        public Version(Session session) : base(session)
        {
        }

        [Persistent("application_oid")]
        public Application Application { get; set; }

        [Persistent("version_code")]
        public string VersionCode { get; set; }

        [Persistent("is_current_version")]
        public bool IsCurrentVersion { get; set; }
    }
}
