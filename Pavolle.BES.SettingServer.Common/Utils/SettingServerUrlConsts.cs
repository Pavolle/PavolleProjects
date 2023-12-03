using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Common.Utils
{
    public class SettingServerConsts
    {
        public class DbConsts
        {
            public const bool IsPostgres=true;
        }

        public class DefinitionUrlConst
        {
            public const string BaseRoute = "api/settingserver/definition";

            public const string GetSettingsTypeListRoutePrefix = "getsettingstypelist";
            public const string GetSettingsCategoriesListRoutePrefix = "getsettingcategorieslist";
        }

        public class SettingsUrlConst
        {
            public const string BaseRoute = "api/settingserver/settings";

            public const string ListRoutePrefix = "list";
            public const string DetailRoutePrefix = "detail/{setting_type}";
            public const string EditRoutePrefix = "edit/{setting_type}";
        }

        public class ServerStatusUrlConst
        {
            public const string BaseRoute = "api/settingserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
        }
    }
}
