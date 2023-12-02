using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.BES.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.ViewModels.ViewData
{
    public class JobViewData
    {
        public long Oid { get; set; }
        public bool Active { get; set; }
        public EBesJobType JobType { get; set; }
        public string Cron { get; set; }
        public string ReadableName { get; set; }
        public DateTime LastRunTime { get; set; }
        public EBesAppType BesAppType { get; set; }
        public string RunServiceUrl { get; set; }
    }
}
