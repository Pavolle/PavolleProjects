using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MobileCore.Models
{
    public class BaseSettingDbModel : BaseDbObject
    {
        public string? AppId { get; set; }
        public bool ProVersion { get; set; }
        public bool SetupDone { get; set; }
        public bool TransitionSound { get; set; }
        public bool BackgroundSound { get; set; }
    }
}
