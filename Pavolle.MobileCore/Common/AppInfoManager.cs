using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MobileCore.Common
{
    public class AppInfoManager:Singleton<AppInfoManager>
    {
        private AppInfoManager() { }

        private string _appVersion;
        public void SetAppVersion(string appVersion) { _appVersion = appVersion; }
        public string GetAppVersion() { return _appVersion; }

        public string GetAppFooter() { return "© Pavolle " + DateTime.Now.Year.ToString() + " V" + _appVersion; }
    }
}
