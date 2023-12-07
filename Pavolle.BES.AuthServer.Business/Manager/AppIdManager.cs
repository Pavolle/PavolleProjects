using log4net;
using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class AppIdManager : Singleton<AppIdManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(AppIdManager));
        Dictionary<string, EBesAppType> _apps;
        private AppIdManager() 
        {
            _apps=new Dictionary<string, EBesAppType>();

            _apps.Add("SESER-PLLE-112317-TA", EBesAppType.CoreSettingServer);
            _apps.Add("AUTHS-PLLE-112328-TA", EBesAppType.CoreAuthServer);


            _apps.Add("PASSE-PLLE-112326-TA", EBesAppType.PasswordServer);
        }

        public EBesAppType? GetBesAppTypeByAppId(string appId)
        {
            if (_apps.ContainsKey(appId)) return _apps[appId];
            else return EBesAppType.Undefined;
        }



    }
}
