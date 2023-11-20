using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.Common.Utils
{
    public class TranslateServerConsts
    {
        public class ServerStatusUrlConst
        {
            public const string Route = "api/translateserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
        }

        public class TranslateDataUrlConst
        {
            public const string Route = "api/translateserver/translatedata";
            public const string EditRoutePrefix = "edit/{oid}";
            public const string GetRoutePrefix = "get/{variable}";
            public const string DetailRoutePrefix = "detail/{oid}";
            public const string BulkDataRoutePrefix = "bulkdata";
        }
    }
}
