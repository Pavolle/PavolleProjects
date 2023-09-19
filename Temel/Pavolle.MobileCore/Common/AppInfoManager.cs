using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MobileCore.Models;
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



        public List<InfoModel> About { get; set; }
        public void SetAbout(List<InfoModel> about) { About = about; }
        public List<string> GetAbout(ELanguage language)
        {
            var data = About.FirstOrDefault(t => t.Language == language);
            if(data == null)
            {
                return new List<string>();
            }
            return data.About;
        }

        public string GetAppFooter() { return "© Pavolle " + DateTime.Now.Year.ToString() + " V" + _appVersion; }
    }
}
