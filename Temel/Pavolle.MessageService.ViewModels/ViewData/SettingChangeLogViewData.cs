using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class SettingChangeLogViewData : ViewDataBase
    {

        public string User { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
