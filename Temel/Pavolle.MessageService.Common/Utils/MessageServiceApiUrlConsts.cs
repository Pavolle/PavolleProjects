namespace Pavolle.MessageService.Common.Utils
{
    public class MessageServiceApiUrlConsts
    {
        public const string ListRoutePrefix = "list";
        public const string LookupRoutePrefix = "lookup";
        public const string ImageLookupRoutePrefix = "imagelookup";
        public const string DetailRoutePrefix = "detail/{oid}";
        public const string AddRoutePrefix = "add";
        public const string EditRoutePrefix = "edit/{oid}";
        public const string DeleteRoutePrefix = "delete/{oid}";

        public class LoginRouteConsts
        {
            public const string Route = "api/login";
            public const string SignInRoutePrefix="signin";
            public const string SignOutRoutePrefix = "signout";
            public const string ForgotPaswordRoutePrefix = "forgotpassword";
            public const string VerifyCodeRoutePrefix = "verifycode";
            public const string ResetPaswordRoutePrefix = "resetcode";
            
        }

        public class ApiServiceRouteConsts
        {
            public const string Route = "api/apiservice";
        }

        public class CityRouteConsts
        {
            public const string Route = "api/city";
        }

        public class CountryRouteConsts
        {
            public const string Route = "api/country";
        }

        public class DefinitionRouteConsts
        {
            public const string Route = "api/definition";
        }

        public class OrganizationRouteConsts
        {
            public const string Route = "api/organization";
        }

        public class JobRouteConsts
        {
            public const string Route = "api/job";
            public const string RunRoutePrefix = "run/{oid}";
        }

        public class SettingRouteConsts
        {
            public const string Route = "api/setting";
        }

        public class TranslateRouteConsts
        {
            public const string Route = "api/translate";
        }

        public class UserRouteConsts
        {
            public const string Route = "api/user";
            public const string MyInfoRoutePrefix = "myinfo";
            public const string EditMyInfoRoutePrefix = "editmyinfo";
            public const string VerifyPhoneRoutePrefix = "verifyphone";
            public const string VerifyEmailRoutePrefix = "verifyemail";
            public const string SendVerificationCodeRoutePrefix = "sendverificationcode";
            public const string ChangePasswordRoutePrefix = "changepassword";
        }

        public class UserGroupRouteConsts
        {
            public const string Route = "api/usergroup";
        }
    }
}
