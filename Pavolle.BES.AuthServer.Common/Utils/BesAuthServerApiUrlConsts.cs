using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Common.Utils
{
    public class BesAuthServerApiUrlConsts
    {
        public const string ListRoutePrefix = "list";
        public const string LookupRoutePrefix = "lookup";
        public const string ImageLookupRoutePrefix = "imagelookup";
        public const string DetailRoutePrefix = "detail/{oid}";
        public const string AddRoutePrefix = "add";
        public const string EditRoutePrefix = "edit/{oid}";
        public const string DeleteRoutePrefix = "delete/{oid}";
        public class AppServiceConsts
        {
            public const string Route = "api/app";
        }
        public class AppTypeServiceConsts
        {
            public const string Route = "api/apptype";
        }
    }
}
