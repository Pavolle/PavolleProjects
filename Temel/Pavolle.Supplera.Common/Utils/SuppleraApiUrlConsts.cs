using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Supplera.Common.Utils
{
    public class SuppleraApiUrlConsts
    {

        public const string ListRoutePrefix = "list";
        public const string LookupRoutePrefix = "lookup";
        public const string DetailRoutePrefix = "detail/{oid}";
        public const string AddRoutePrefix = "add";
        public const string EditRoutePrefix = "edit/{oid}";

        public class KurumConsts
        {
            public const string Route = "company";
        }

        public class UyelikBasvuruRouteConsts
        {
            public const string Route = "membership";
            public const string UyelikBasvuruDetayRoutePrefix = "detail";
            public const string AddMessageRoutePrefix = "sendMessage";
        }

        public class UyelikBasvuruIslemRouteConsts
        {
            public const string Route = "membershipoperation";
        }
    }
}
