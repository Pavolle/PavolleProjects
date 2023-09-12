using Pavolle.Core.ViewModels.ViewData;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class JobDetailViewData : ViewDataBase
    {

        public EJobType JobType { get; set; }
        public string JobTypeString { get; set; }
        public string Name { get; set; }
        public string Cron { get; set; }
        public DateTime LastRunTime { get; set; }
        public bool Active { get; set; }
    }
}
