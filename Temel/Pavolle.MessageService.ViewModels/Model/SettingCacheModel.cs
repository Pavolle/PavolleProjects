using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class SettingCacheModel
    {
        public long Oid { get; set; }
        public ESettingType SettingType { get; set; }
        public string Value { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public string SettingName { get; set; }
    }
}
