using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.DbModels.Entities
{
    [Persistent("job_run_logs")]
    public class JobRunLog : BaseObject
    {
        public JobRunLog(Session session) : base(session)
        {
        }

        [Persistent("job_oid")]
        public Job Job { get; set; }

        [Persistent("success")]
        public bool Success { get; set; }

        [Persistent("result")]
        [Size(1000)]
        public string Result { get; set; }
    }
}
