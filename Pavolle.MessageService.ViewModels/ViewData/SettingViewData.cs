using Pavolle.Core.ViewModels.ViewData;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class SettingViewData : ViewDataBase
    {
        public string SettingName { get; set; }
        public string Value { get; set; }
    }
}
