using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.WebSecurity
{
    internal class SecurityConstsManagerCreatorManager : Singleton<SecurityConstsManagerCreatorManager>
    {
        private SecurityConstsManagerCreatorManager() { }

        public bool Create(string organizationName, string projectName, string projectPath, string issuer, string audience, string webSecurityKey)
        {
            string projectNameRoot = organizationName + "." + projectName;
            string classString = "";
            classString += "using Microsoft.IdentityModel.Tokens;" + Environment.NewLine;
            classString += "using "+organizationName+".Core.Utils;" + Environment.NewLine;
            classString += "using System.Text;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + projectNameRoot + ".WebSecurity" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class " + projectName + "SecurityConstsManager : Singleton<" + projectName + "SecurityConstsManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public const string SymmetricSecurityKeyString = \"" + string.Format(webSecurityKey, issuer, organizationName.ToUpper(), issuer) + "\";" + Environment.NewLine;
            classString += "        public const string Issuer = \"" + issuer + "\";" + Environment.NewLine;
            classString += "        public const string Audience = \"" + audience + "\";" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private readonly string UsernameKey;" + Environment.NewLine;
            classString += "        private readonly string SesionIdKey;" + Environment.NewLine;
            classString += "        private readonly string UserGroupOidKey;" + Environment.NewLine;
            classString += "        private readonly string UserTypeKey;" + Environment.NewLine;
            classString += "        private readonly string LanguageKey;" + Environment.NewLine;
            classString += "        private readonly SymmetricSecurityKey key;" + Environment.NewLine;
            classString += "        private readonly string RequestIpKey;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private " + projectName + "SecurityConstsManager()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            UsernameKey = \"Username\";" + Environment.NewLine;
            classString += "            LanguageKey = \"Language\";" + Environment.NewLine;
            classString += "            SesionIdKey = \"SessionId\";" + Environment.NewLine;
            classString += "            UserTypeKey = \"UserType\";" + Environment.NewLine;
            classString += "            UserGroupOidKey = \"UserGroupOid\";" + Environment.NewLine;
            classString += "            RequestIpKey = \"RequestIP\";" + Environment.NewLine;
            classString += "            key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SymmetricSecurityKeyString)) { KeyId = \"1000\" };" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetRequestIp()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return RequestIpKey;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetLanguageKey()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return LanguageKey;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetUsernameKey()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return UsernameKey;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetSesionIdKey()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return SesionIdKey;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetSymmetricSecurityKeyString()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return SymmetricSecurityKeyString;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public SymmetricSecurityKey GetKey()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return key;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetUserGroupOidKey()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return UserGroupOidKey;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetUserTypeKey()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return UserTypeKey;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetKeyString()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return SymmetricSecurityKeyString;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + projectNameRoot + ".WebSecurity", "", projectName + "SecurityConstsManager.cs", classString);
        }
    }
}
