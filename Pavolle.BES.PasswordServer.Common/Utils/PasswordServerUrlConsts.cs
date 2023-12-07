using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.Common.Utils
{
    public class PasswordServerUrlConsts
    {

        public class ServerStatusUrlConst
        {
            public const string BaseRoute = "api/passwordserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
            public const string ReloadAllServerSettingsRoutePrefix = "reloadallsettings";
        }

        public class LoginUrlConsts
        {
            public const string BaseRoute = "api/passwordserver/login";

            public const string SignInRoutePrefix = "signin";
            public const string SignOutRoutePrefix = "signout";
            public const string ForgotPaswordRoutePrefix = "forgotpassword";
            public const string ResetPaswordRoutePrefix = "resetpassword";

        }

        public class PasswordConsts
        {
            public const string BaseRoute = "api/passwordserver/password";
            public const string AccessRoutePrefx = "access";
            public const string ListRoutePrefix = "list";
            public const string EditRoutePrefix = "edit";
            public const string AddRoutePrefix = "add";

            public const string AddAuthorityForRoleRoutePrefix = "addauthorityforrole";
            public const string DeleteAuthorityForRoleRoutePrefix = "deleteauthorityforrole";
            public const string ListAuthorityForRoleRoutePrefix = "listauthorityforrole";

            public const string AddAuthorityForUserRoutePrefix = "addauthorityforuser";
            public const string DeleteAuthorityForUserRoutePrefix = "deleteauthorityforuser";
            public const string ListAuthorityForUserRoutePrefix = "listauthorityforuser";
        }
    }
}
