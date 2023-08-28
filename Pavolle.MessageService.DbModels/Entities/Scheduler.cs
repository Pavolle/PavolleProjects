using DevExpress.Xpo;
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

        public ESchedulerType SchedulerType { get; set; }
        public string Name { get; set; }
        public string Cron { get; set; }
        public DateTime LastRunTime { get; set; }
    }
}
