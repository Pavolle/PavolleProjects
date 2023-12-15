using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Common.Utils
{
    public class DYSIntegrationsConsts
    {
        public class SuppleraIntegrationUrlConsts
        {
            public const string Route = "api/dys/integration/supplera";
            public const string SaveBomFileRoutePrefix = "savebomfile";
        }

        public class ServerStatusUrlConst
        {
            public const string Route = "api/dys/integration/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
        }
    }
}
