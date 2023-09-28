using Pavolle.SmartAppCoder.Business.Core.Utils;
using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.Common.Utils
{
    public class ApiUrlConstsCreatorManager : Singleton<ApiUrlConstsCreatorManager>
    {
        private ApiUrlConstsCreatorManager() { }


        public bool Create(string organizationName, string projectName, string projectPath)
        {
            string className = projectName + "ApiUrlConsts";
            string projectRoot = organizationName + "." + projectName;
            string classString = "";
            classString += "namespace "+ projectRoot + ".Common.Utils" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class " + className + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public const string ListRoutePrefix = \"list\";" + Environment.NewLine;
            classString += "        public const string LookupRoutePrefix = \"lookup\";" + Environment.NewLine;
            classString += "        public const string ImageLookupRoutePrefix = \"imagelookup\";" + Environment.NewLine;
            classString += "        public const string DetailRoutePrefix = \"detail/{oid}\";" + Environment.NewLine;
            classString += "        public const string AddRoutePrefix = \"add\";" + Environment.NewLine;
            classString += "        public const string EditRoutePrefix = \"edit/{oid}\";" + Environment.NewLine;
            classString += "        public const string DeleteRoutePrefix = \"delete/{oid}\";" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class LoginRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/login\";" + Environment.NewLine;
            classString += "            public const string SignInRoutePrefix=\"signin\";" + Environment.NewLine;
            classString += "            public const string SignOutRoutePrefix = \"signout\";" + Environment.NewLine;
            classString += "            public const string ForgotPaswordRoutePrefix = \"forgotpassword\";" + Environment.NewLine;
            classString += "            public const string VerifyCodeRoutePrefix = \"verifycode\";" + Environment.NewLine;
            classString += "            public const string ResetPaswordRoutePrefix = \"resetcode\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class ApiServiceRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/apiservice\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class CityRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/city\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class CountryRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/country\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class DefinitionRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/definition\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class OrganizationRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/organization\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class JobRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/job\";" + Environment.NewLine;
            classString += "            public const string RunRoutePrefix = \"run/{oid}\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class SettingRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/setting\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class TranslateRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/translate\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class UserRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/user\";" + Environment.NewLine;
            classString += "            public const string MyInfoRoutePrefix = \"myinfo\";" + Environment.NewLine;
            classString += "            public const string EditMyInfoRoutePrefix = \"editmyinfo\";" + Environment.NewLine;
            classString += "            public const string VerifyPhoneRoutePrefix = \"verifyphone\";" + Environment.NewLine;
            classString += "            public const string VerifyEmailRoutePrefix = \"verifyemail\";" + Environment.NewLine;
            classString += "            public const string SendVerificationCodeRoutePrefix = \"sendverificationcode\";" + Environment.NewLine;
            classString += "            public const string ChangePasswordRoutePrefix = \"changepassword\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class UserGroupRouteConsts" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public const string Route = \"api/usergroup\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + projectRoot + ".Common", "Utils", projectName + "ApiUrlConsts.cs", classString);

        }
    }
}

