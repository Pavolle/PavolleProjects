using Pavolle.Core.ViewModels.ViewData;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class JobViewData : ViewDataBase
    {
        public EJobType? JobType { get; set; }
        public bool Active { get; set; }
        public string Cron { get; set; }
        public string ReadableName { get; set; }
        public DateTime? LastRunTime { get; set; }
    }
}
