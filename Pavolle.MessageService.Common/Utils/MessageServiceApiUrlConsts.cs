using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Common.Utils
{
    public class MessageServiceApiUrlConsts
    {
        public const string ListRoutePrefix = "list";
        public const string LookupRoutePrefix = "lookup";
        public const string DetailRoutePrefix = "detail/{oid}";
        public const string AddRoutePrefix = "add";
        public const string EditRoutePrefix = "edit/{oid}";
        public const string DeleteRoutePrefix = "delete/{oid}";

        public class AppRouteConsts
        {
            public const string Route = "ms/api/app";
        }

        public class AuthRouteConsts
        {
            public const string Route = "ms/api/auth";
        }

        public class CompanyRouteConsts
        {
            public const string Route = "ms/api/company";
        }

        public class DefinitionRouteConsts
        {
            public const string Route = "ms/api/definition";
        }

        public class LoginRouteConsts
        {
            public const string Route = "ms/api/login";
            public const string SignInRoutePrefix="signin";
            public const string SignOutRoutePrefix = "signout";
            public const string ForgotPaswordRoutePrefix = "forgotpassword";
        }

        public class MessageRouteConsts
        {
            public const string Route = "ms/api/message";
        }

        public class MessageManagmentRouteConsts
        {
            public const string Route = "ms/api/messagemanagment";
        }

        public class SettingsRouteConsts
        {
            public const string Route = "ms/api/settings";
        }

        public class UserRouteConsts
        {
            public const string Route = "ms/api/user";
            public const string ChangePasswordRoutePrefix = "changepassword";
            public const string MyInfoRoutePrefix = "info";
        }

        public class SchedulerRouteConsts
        {
            public const string Route = "ms/api/scheduler";
            public const string RunRoutePrefix = "run";
        }

        public class VersionChangeRouteConsts
        {
            public const string Route = "ms/api/versionchange";
        }

        public class IssueRouteConsts
        {
            public const string Route = "ms/api/issue";
        }

        public class VersionRouteConsts
        {
            public const string Route = "ms/api/version";
        }

        public class NotificationRouteConsts
        {
            public const string Route = "ms/api/notification";
        }

        public class AppErrorRouteConsts
        {
            public const string Route = "ms/api/error";
        }
    }
}
