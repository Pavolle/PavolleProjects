using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MembershipServer.Common.Utils
{
    public class MembershipServerUrlConsts
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
            public const string BaseRoute = "api/membershipserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
            public const string ReloadAllServerSettingsRoutePrefix = "reloadallsettings";
        }

        public class MembershipUrlConsts
        {
            public const string BaseRoute = "api/membershipserver/membership";
            public const string CancelRoutePrefix = "cancel/{oid}";
            public const string CreateAccountRoutePrefix = "createaccount/{oid}";
            public const string AddCommentRoutePrefix = "addcomment/{oid}";
            public const string ChangeStatusRoutePrefix = "changestatus/{oid}";
        }

        public class DefinitionUrlConsts
        {
            public const string BaseRoute = "api/membershipserver/definition";

            public const string MembershipRequestStatusRoutePrefix = "membershiprequeststatus";
        }
    }
}
