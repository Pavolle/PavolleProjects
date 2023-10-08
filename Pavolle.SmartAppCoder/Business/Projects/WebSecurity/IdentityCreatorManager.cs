using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.WebSecurity
{
    public class IdentityCreatorManager : Singleton<IdentityCreatorManager>
    {
        private IdentityCreatorManager() { }

        public bool Create(string organizationName, string projectName, string projectPath)
        {
            string projectNameRoot = organizationName + "." + projectName;
            string classString = "";
            classString += "using System.Security.Principal;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + projectNameRoot + ".WebSecurity" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class " + projectName + "Identity : IIdentity" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public " + projectName + "Identity(string name, string authenticationType)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            Name = name;" + Environment.NewLine;
            classString += "            IsAuthenticated = true;" + Environment.NewLine;
            classString += "            AuthenticationType = authenticationType;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string Name { get; private set; }" + Environment.NewLine;
            classString += "        public string AuthenticationType { get; private set; }" + Environment.NewLine;
            classString += "        public bool IsAuthenticated { get; private set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + projectNameRoot + ".WebSecurity", "", projectName + "Identity.cs", classString);
        }
    }
}
