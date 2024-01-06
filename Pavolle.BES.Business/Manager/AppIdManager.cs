using log4net;
using Pavolle.BES.Common.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Business
{
    public class AppIdManager : Singleton<AppIdManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(AppIdManager));
        Dictionary<string, EBesAppType> _apps;
        Dictionary<EBesAppType, string> _appsById;
        private AppIdManager() 
        {
            _apps=new Dictionary<string, EBesAppType>();
            _appsById = new Dictionary<EBesAppType, string>();

            _apps.Add("SESER-PLLE-112317-TA", EBesAppType.CoreSettingServer);
            _appsById.Add(EBesAppType.CoreSettingServer, "SESER-PLLE-112317-TA");


            _apps.Add("AUTHS-PLLE-112328-TA", EBesAppType.CoreAuthServer);
            _appsById.Add(EBesAppType.CoreAuthServer, "AUTHS-PLLE-112328-TA");


            _apps.Add("TRTES-PLLE-112320-TA", EBesAppType.CoreTranslateServer);
            _appsById.Add(EBesAppType.CoreTranslateServer, "TRTES-PLLE-112320-TA");



            _apps.Add("PASSE-PLLE-112326-TA", EBesAppType.PasswordServer);
            _appsById.Add(EBesAppType.PasswordServer, "PASSE-PLLE-112326-TA");

            _apps.Add("JEOSR-PLLE-012401-TA", EBesAppType.GeolocationServer);
            _appsById.Add(EBesAppType.GeolocationServer, "JEOSR-PLLE-012401-TA");
        }

        public EBesAppType GetBesAppTypeByAppId(string appId)
        {
            if (_apps.ContainsKey(appId)) return _apps[appId];
            else return EBesAppType.Undefined;
        }

        public string GetBesAppIdByBesType(EBesAppType appType)
        {
            if (_appsById.ContainsKey(appType)) return _appsById[appType];
            else return string.Empty;
        }



    }
}
