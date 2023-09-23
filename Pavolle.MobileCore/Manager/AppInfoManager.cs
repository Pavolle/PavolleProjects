using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MobileCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MobileCore.Manager
{
    public class AppInfoManager : Singleton<AppInfoManager>
    {
        AppInfoModel _appInfo;
        private AppInfoManager()
        {
        }

        public void Initialize(AppInfoModel appInfo)
        {
            _appInfo = appInfo;
        }

        public string GetAppVersion()
        {
            return _appInfo.AppVersion;
        }

        public string GetAppFooterInfo(ELanguage language)
        {
            switch (language)
            {
                case ELanguage.English:
                    return "©Pavolle " + DateTime.Now.Year.ToString() + "V" + GetAppVersion();
                case ELanguage.Turkish:
                    return "©Pavolle Bilişim " + DateTime.Now.Year.ToString() + "V" + GetAppVersion();
                default:
                    return "©Pavolle " + "V" + DateTime.Now.Year.ToString() + GetAppVersion();
            }
        }

        public string GetAppName(ELanguage language)
        {
            var data=_appInfo.AppNames.FirstOrDefault(x => x.Language == language);
            if(data == null)
            {
                return string.Empty;
            }
            return data.AppName;
        }

        public List<string> GetAbout(ELanguage language)
        {
            var data = _appInfo.Abouts.FirstOrDefault(x => x.Language == language);
            if (data == null)
            {
                return new List<string>();
            }
            return data.About;
        }
    }
}
