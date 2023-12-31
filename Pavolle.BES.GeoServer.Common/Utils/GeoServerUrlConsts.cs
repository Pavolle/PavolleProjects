using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.Common.Utils
{
    public class GeoServerUrlConsts
    {
        public const string ListRoutePrefix = "list";
        public const string LookupRoutePrefix = "lookup";
        public const string ImageLookupRoutePrefix = "imagelookup";
        public const string DetailRoutePrefix = "detail/{oid}";
        public const string AddRoutePrefix = "add";
        public const string EditRoutePrefix = "edit/{oid}";
        public const string DeleteRoutePrefix = "delete/{oid}";

        public class ServerStatusUrlConsts
        {
            public const string BaseRoute = "api/geoserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
            public const string ReloadAllServerSettingsRoutePrefix = "reloadallsettings";
        }

        public class CountryUrlConsts
        {
            public const string BaseRoute = "api/geoserver/country";
        }

        public class CityUrlConsts
        {
            public const string BaseRoute = "api/geoserver/city";
        }

        public class DistrictUrlConsts
        {
            public const string BaseRoute = "api/geoserver/district";
        }

        public class AddressUrlConsts
        {
            public const string BaseRoute = "api/geoserver/address";
        }
    }
}
