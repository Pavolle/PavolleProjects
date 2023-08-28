using DevExpress.Xpo;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Name { get; set; }

        [Persistent("cron")]
        public string Cron { get; set; }

        [Persistent("last_run_time")]
        public DateTime LastRunTime { get; set; }
    }
}
