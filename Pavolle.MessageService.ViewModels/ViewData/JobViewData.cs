using Pavolle.MessageService.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class JobViewData : MessageServiceViewDataBase
    {
        public EJobType JobType { get; set; }
        public string Name { get; set; }
        public string Cron { get; set; }
        public DateTime LastRunTime { get; set; }
        public bool Active { get; set; }
    }
}
