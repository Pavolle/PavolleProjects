using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.WebSecurity
{
    public class PrincipalCreatorManager : Singleton<PrincipalCreatorManager>
    {
        private PrincipalCreatorManager() { }

        public bool Create(string organizationName, string projectName, string projectPath)
        {
            string projectNameRoot = organizationName + "." + projectName;
            string classString = "";

            classString += "using "+organizationName+".Core.Enums;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".Common.Enums;" + Environment.NewLine;
            classString += "using System.Security.Principal;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + projectNameRoot + ".WebSecurity" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class " + projectName + "Principal : IPrincipal" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public " + projectName + "Principal(" + projectName + "Identity identity,  string sessionId, long? userGroupOid, EUserType? userType, ELanguage? language, string requestIp)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            if (identity == null)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                //TODO Log indentity error" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            this.Identity = identity;" + Environment.NewLine;
            classString += "            this.SessionId = sessionId;" + Environment.NewLine;
            classString += "            this.UserGroupOid = userGroupOid;" + Environment.NewLine;
            classString += "            this.UserType = userType;" + Environment.NewLine;
            classString += "            this.Language = language;" + Environment.NewLine;
            classString += "            this.RequestIp = requestIp;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public IIdentity Identity { get; private set; }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string SessionId { get; set; }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public long? UserGroupOid { get; set; }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public EUserType? UserType { get; set; }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public ELanguage? Language { get; set; }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string RequestIp { get; set; }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public bool IsInRole(string role)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return false;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + projectNameRoot + ".WebSecurity", "", projectName + "Principal.cs", classString);
        }
    }
}
