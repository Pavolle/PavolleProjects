using DevExpress.Xpo;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("schedulers")]
    public class Scheduler : BaseObject
    {
        public Scheduler(Session session) : base(session)
        {
        }

        [Persistent("scheduler_type")]
        public ESchedulerType SchedulerType { get; set; }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("cron")]
        [Size(30)]
        public string Cron { get; set; }

        [Persistent("last_run_time")]
        public DateTime LastRunTime { get; set; }
    }
}
