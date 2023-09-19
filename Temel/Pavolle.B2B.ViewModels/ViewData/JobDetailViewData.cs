using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.B2B.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.B2B.ViewModels.ViewData
{
    public class JobDetailViewData : B2BViewDataBase
    {
        public EJobType JobType { get; set; }
        public string Name { get; set; }
        public string Cron { get; set; }
        public DateTime LastRunTime { get; set; }
        public bool Active { get; set; }
    }
}
