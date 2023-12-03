using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.Common.Utils
{
    public class JobServerUrlConsts
    {
        public class ServerStatusUrlConst
        {
            public const string BaseRoute = "api/jobserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
            public const string ReloadAllServerSettingsRoutePrefix = "reloadallsettings";
        }

        public class JobServiceConsts
        {
            public const string BaseRoute = "api/jobserver/job";

            public const string ListRoutePrefix = "list";
            public const string DetailRoutePrefix = "detail/{oid}";
            public const string AddRoutePrefix = "add";
            public const string EditRoutePrefix = "edit/{oid}";
            public const string RunRoutePrefix = "run/{oid}";
        }
    }
}
