using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("job_change_logs")]
    public class JobChangeLog : BaseObject
    {
        public JobChangeLog(Session session) : base(session) {}

        [Persistent("job_oid")]
        public Job Job { get; set; }

        [Persistent("old_name")]
        [Size(255)]
        public string OldName { get; set; }

        [Persistent("new_name")]
        [Size(255)]
        public string NewName { get; set; }

        [Persistent("old_cron")]
        [Size(30)]
        public string OldCron { get; set; }

        [Persistent("new_cron")]
        [Size(30)]
        public string NewCron { get; set; }

        [Persistent("old_active")]
        public bool OldActive { get; set; }

        [Persistent("new_active")]
        public bool NewActive { get; set; }

    }
}
