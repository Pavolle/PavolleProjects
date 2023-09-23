using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MobileCore.Models
{
    public class AppInfoModel
    {
        public string AppVersion { get; set; }
        public List<AppNameModel> AppNames { get; set; }
        public List<AppAboutModel> Abouts { get; set; }
    }
}
