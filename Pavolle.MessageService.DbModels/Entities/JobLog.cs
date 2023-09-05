using DevExpress.Xpo;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("scheduler_logs")]
    public class JobLog : BaseObject
    {
        public JobLog(Session session) : base(session)
        {
        }

        [Persistent("job_oid")]
        public Job Job { get; set; }

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
