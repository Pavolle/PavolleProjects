using DevExpress.Xpo;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("scheduler_logs")]
    public class SchedulerLog : BaseObject
    {

        public SchedulerLog(Session session) : base(session)
        {
        }

        [Persistent("scheduler_oid")]
        public Scheduler Scheduler { get; set; }

        [Persistent("start_time")]
        public DateTime StartTime { get; set; }

        [Persistent("end_time")]
        public DateTime EndTime { get; set; }

        [Persistent("success")]
        public bool Success { get; set; }

        [Persistent("result")]
        [Size(1000)]
        public string Result { get; set; }
    }
}
