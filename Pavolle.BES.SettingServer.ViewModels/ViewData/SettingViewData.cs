using Pavolle.BES.SettingServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.ViewModels.ViewData
{
    public class SettingViewData
    {
        public ESettingType SettingType { get; set; }
        public string SettingTypeName { get; set; }
        public string Value { get; set; }
    }
}
