using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.LogServer.Common.Utils
{
    public class LogServerConsts
    {



        public class ServerStatusUrlConst
        {
            public const string BaseRoute = "api/logsserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
            public const string ReloadAllServerSettingsRoutePrefix = "reloadallsettings";
        }

        public class LogUrlConst
        {
            public const string BaseRoute = "api/logsserver/log";
            public const string SaveRoutePrefix = "save";
        }
    }
}
