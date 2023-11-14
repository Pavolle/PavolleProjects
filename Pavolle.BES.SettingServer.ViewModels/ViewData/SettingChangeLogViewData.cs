using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.ViewModels.ViewData
{
    public class SettingChangeLogViewData
    {
        public DateTime ChangeTime { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
