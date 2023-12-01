using DevExpress.Xpo;
using Pavolle.BES.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.DbModels.Entities
{
    public class Job : BaseObject
    {
        public Job(Session session) : base(session)
        {
        }

        public bool Active { get; set; }
        public EBesJobType JobType { get; set; }
        public string Cron { get; set; }
        public string ReadableName { get; set; }
        public DateTime LastRunTime { get; set; }
    }
}
