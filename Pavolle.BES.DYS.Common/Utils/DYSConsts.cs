using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Common.Utils
{
    public class DYSConsts
    {
        public const string ListRoutePrefix = "list";
        public const string LookupRoutePrefix = "lookup";
        public const string ImageLookupRoutePrefix = "imagelookup";
        public const string AddRoutePrefix = "add";
        public const string EditRoutePrefix = "edit/{oid}";
        public const string DetailRoutePrefix = "detail/{oid}";
        public const string DeleteRoutePrefix = "delete/{oid}";
        public class ServerStatusUrlConst
        {
            public const string Route = "api/dysserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
        }

        public class FolderUrlConst
        {
            public const string BaseRoute = "api/dysserver/folder";

            public const string MoveRoutePrefix = "move";
        }

        public class DocumentAccessConsts
        {
            public const string BaseRoute = "api/dysserver/documentaccess";
        }
    }
}
