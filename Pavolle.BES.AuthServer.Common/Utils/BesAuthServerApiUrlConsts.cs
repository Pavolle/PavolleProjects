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
        
        public class ApiServiceUrlConsts
        {
            public const string BaseRoute = "api/authserver/apiservice";
        }
        public class CommunicationInfoUrlConsts
        {
            public const string BaseRoute = "api/authserver/communicationinfo";
        }
        public class OrganizationUrlConsts
        {
            public const string BaseRoute = "api/authserver/organization";
        }

        public class PersonUrlConsts
        {
            public const string BaseRoute = "api/authserver/person";
        }

        public class RoleUrlConsts
        {
            public const string BaseRoute = "api/authserver/role";
        }

        public class SesionUrlConsts
        {
            public const string BaseRoute = "api/authserver/session";
        }

        public class UserUrlConsts
        {
            public const string BaseRoute = "api/authserver/user";
        }

        public class ServerStatusUrlConsts
        {
            public const string BaseRoute = "api/authserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
            public const string ReloadAllServerSettingsRoutePrefix = "reloadallsettings";
        }

        public class LoginUrlConsts
        {
            public const string BaseRoute = "api/login";

            public const string SignInRoutePrefix = "signin";
            public const string SignOutRoutePrefix = "signout";
            public const string ForgotPaswordRoutePrefix = "forgotpassword";
            public const string ResetPaswordRoutePrefix = "resetpassword";

        }
    }
}
