using DevExpress.Xpo;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("jobs")]
    public class Job : BaseObject
    {
        public Job(Session session) : base(session) {}

        [Persistent("job_type")]
        public EJobType JobType { get; set; }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("cron")]
        [Size(30)]
        public string Cron { get; set; }

        [Persistent("last_run_time")]
        public DateTime? LastRunTime { get; set; }

        [Persistent("active")]
        public bool Active { get; set; }

    }
}
