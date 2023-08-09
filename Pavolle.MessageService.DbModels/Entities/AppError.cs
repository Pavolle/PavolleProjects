using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("app_errors")]
    public class AppError : BaseObject
    {
        public AppError(Session session) : base(session)
        {
        }

        [Persistent("app_oid")]
        public App App { get; set; }

        [Persistent("app_version_oid")]
        public AppVersion AppVersion { get; set; }

        [Persistent("header")]
        public string Header { get; set; }

        [Persistent("content")]
        public string Content { get; set; }
    }
}
